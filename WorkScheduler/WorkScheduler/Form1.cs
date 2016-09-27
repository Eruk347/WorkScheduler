using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkScheduler
{
    public partial class Form1 : Form
    {
        int prevSelect, prev2Select;
        List<DateTime> dates = new List<DateTime>();
        List<Team> teams = new List<Team>();
        Random rnd = new Random(DateTime.Now.Millisecond);

        public Form1()
        {
            InitializeComponent();
        }

        private int teamSum(int max)
        {
            int send = 0;
            for (int i = 1; i < max + 1; i++)
            {
                send += i;
            }
            return send;
        }

        private void springFallGetDate_Click(object sender, EventArgs e)
        {
            dateList.Items.Clear();
            dates.Clear();
            DateTime first = new DateTime(main13Start.Value.Year, main13Start.Value.Month, main13Start.Value.Day);
            DateTime second = new DateTime(main13End.Value.Year, main13End.Value.Month, main13End.Value.Day);
            for (int i = 0; i < 2; i++)
            {
                for (DateTime select = first; select <= second; select = select.AddDays(1))
                {
                    if (select.DayOfWeek == DayOfWeek.Tuesday || select.DayOfWeek == DayOfWeek.Friday)
                    {
                        dates.Add(select);
                    }
                }

                first = new DateTime(second3Start.Value.Year, second3Start.Value.Month, second3Start.Value.Day);
                second = new DateTime(second3End.Value.Year, second3End.Value.Month, second3End.Value.Day);
            }
            for (int i = 0; i < dates.Count; i++)
            {

                dateList.Items.Add(dates[i]);
            }
            label6.Text = dates.Count.ToString();
        }

        private void addTeam_Click(object sender, EventArgs e)
        {
            List<String> dates = new List<String>();
            for (int i = 0; i < dateList.Items.Count; i++)
            {
                if (dateList.GetSelected(i))
                {
                    dates.Add(dateList.GetItemText(i));
                }
            }
            Team nyt = new Team(teamName.Text, dates, 0);
            teams.Add(nyt);
            teamList.Items.Add(teamName.Text);
            dateList.ClearSelected();
            teamName.Text = "";
        }

        private void teamList_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateList.ClearSelected();
            for (int i = 0; i < teams.Count; i++)
            {
                Team ny = teams[i];
                if (teamList.SelectedItem.ToString() == ny.name)
                {
                    for (int j = 0; j < dates.Count; j++)
                    {
                        for (int k = 0; k < ny.dates.Count; k++)
                        {
                            if (dateList.Items.Contains(ny.dates[k]))
                            {
                                dateList.SetSelected(j, true);
                            }
                        }
                    }
                }
            }
        }

        private void teamName_TextChanged(object sender, EventArgs e)
        {
            dateList.ClearSelected();
        }

        private void main13Start_ValueChanged(object sender, EventArgs e)
        {
            if (main13End.Value < main13Start.Value)
                main13End.Value = main13Start.Value;
        }

        private void main13End_ValueChanged(object sender, EventArgs e)
        {
            if (second3Start.Value < main13End.Value)
                second3Start.Value = main13End.Value;
        }
        private void second3Start_ValueChanged(object sender, EventArgs e)
        {
            if (second3End.Value < second3Start.Value)
                second3End.Value = second3Start.Value;
        }

        private void createListButton_Click(object sender, EventArgs e)
        {
            if (priorityFriday.Checked == true || priorityTuesday.Checked == true)
            {
                List<DateTime> tuesdays = new List<DateTime>();
                List<DateTime> fridays = new List<DateTime>();
                for (int i = 0; i < dates.Count; i++)
                {
                    if (dates[i].DayOfWeek.ToString() == "Friday")
                    {
                        fridays.Add(dates[i]);
                    }
                    if (dates[i].DayOfWeek.ToString() == "Tuesday")
                    {
                        tuesdays.Add(dates[i]);
                    }
                }
                if (priorityFriday.Checked == true)
                {
                    dates.Clear();
                    dates.AddRange(fridays);
                    dates.AddRange(tuesdays);
                }
                else if (priorityTuesday.Checked == true)
                {
                    dates.Clear();
                    dates.AddRange(tuesdays);
                    dates.AddRange(fridays);
                }
            }
            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = dates.Count - 1;

            int[] teamsTried = new int[teams.Count];
            listBox1.Items.Clear();
            for (int i = 0; i < dates.Count;)
            {
                progressBar1.Value = i;
                progressBar1.Update();
                rnd = new Random(DateTime.Now.Millisecond + listBox1.Items.Count);
                int localTeam = rnd.Next(0, teamList.Items.Count);

                teamsTried[localTeam] = localTeam;
                if (teamsTried.Sum() == teamSum(teams.Count-1))
                {
                    i++;
                }
                else
                {
                    if (localTeam != prevSelect && localTeam != prev2Select)
                    {
                        prev2Select = prevSelect;
                        prevSelect = localTeam;
                        Team ny = teams[localTeam];
                        if (ny.shift < numberOfShifts.Value)
                        {
                            bool flag = false;
                            for (int j = 0; j < ny.dates.Count; j++)
                            {
                                if (dates[i].ToString() == ny.dates[j].ToString())
                                {
                                    flag = true;
                                    break;
                                }
                            }
                            if (flag == false)
                            {
                                teams[localTeam].shift += 1;
                                listBox1.Items.Add(dates[i] + " " + ny.name);
                                i++;
                                for (int k = 0; k < teamsTried.Length; k++)
                                {
                                    teamsTried[k] = 0;
                                }
                            }
                        }
                    }
                }
            }
            
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Public\Nymappe\list.txt"))
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    file.WriteLine(listBox1.Items[i]);
                }
            }
        }

        private void loadTeamList_Click(object sender, EventArgs e)
        {
            string[] loadTeams = System.IO.File.ReadAllLines(@"C:\users\public\nymappe\teams.txt");
            for (int i = 0; i < loadTeams.Length; i++)
            {
                string[] singleTeam = loadTeams[i].Split(',');
                string[] teamDates = singleTeam[1].Split('.');
                Team ny = new Team(singleTeam[0], teamDates.ToList(), Convert.ToInt32(singleTeam[2]));
                teams.Add(ny);
                teamList.Items.Add(ny.name);
            }
        }
    }
}
