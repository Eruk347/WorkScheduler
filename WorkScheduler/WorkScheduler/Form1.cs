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
        Random rand = new Random();
        int prevSelect;
        List<string> dates = new List<string>();
        List<Team> teams = new List<Team>();
        public void fillTeamList()
        {
            string[,] teamArray = new string[teams.Count, dates.Count];

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void springFallGetDate_Click(object sender, EventArgs e)
        {
            dateList.Items.Clear();
            dates.Clear();
            DateTime first = new DateTime(main13Start.Value.Year, main13Start.Value.Month, main13Start.Value.Day);
            DateTime second = new DateTime(main13End.Value.Year, main13End.Value.Month, main13End.Value.Day);
            for (DateTime select = first; select <= second; select = select.AddDays(1))
            {
                if (select.DayOfWeek == DayOfWeek.Tuesday || select.DayOfWeek == DayOfWeek.Friday)
                {
                    dates.Add(select.Date.ToString());
                }
            }
            first = new DateTime(second3Start.Value.Year, second3Start.Value.Month, second3Start.Value.Day);
            second = new DateTime(second3End.Value.Year, second3End.Value.Month, second3End.Value.Day);
            for (DateTime select = first; select <= second; select = select.AddDays(1))
            {
                if (select.DayOfWeek == DayOfWeek.Tuesday || select.DayOfWeek == DayOfWeek.Friday)
                {
                    dates.Add(select.Date.ToString());
                }
            }
            for (int i = 0; i < dates.Count; i++)
            {
                var date = dates[i];
                dateList.Items.Add(date);
            }
        }

        private void second3Start_ValueChanged(object sender, EventArgs e)
        {
            second3End.Value = second3Start.Value;
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
                            if (j.ToString() == ny.dates[k])
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

        private void main13End_ValueChanged(object sender, EventArgs e)
        {
            second3Start.Value = main13End.Value;
        }

        private void createListButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dates.Count;)
            {
                int select = rand.Next(0, teams.Count);
                if (select != prevSelect)
                {
                    prevSelect = select;
                    Team ny = teams[select];
                    if (ny.shift < numberOfShifts.Value)
                    {
                        for (int j = 0; j < ny.dates.Count; j++)
                        {
                            if (ny.dates[j] == dates[i])
                            {
                                break;
                            }
                            else
                            {
                                teams[select].shift++;
                                finalList.Items.Add(ny.name);
                                i++;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void loadTeams_Click(object sender, EventArgs e)
        {
            teamList.Items.Clear();
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader("C:\\Users\\Public\\teams\\teams.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] team = line.Split(',');
                string[] dates = team[1].Split(',');
                Team ny = new Team(team[0], dates.ToList(), Convert.ToInt32(team[2]));
                teams.Add(ny);
                teamList.Items.Add(team[0]);
            }
            file.Close();
        }
    }
}
