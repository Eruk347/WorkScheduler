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

        public static List<DateTime> dates = new List<DateTime>();
        public static List<DateTime> datesExeption = new List<DateTime>();
        public static List<Team> teams = new List<Team>();
        public static List<String> finalDates = new List<string>();
        public static List<string>[] bufferDateList = new List<string>[0];//dates.Count]; //dates.count was used when it was part of the button that created the list
        public static Random rnd = new Random(DateTime.Now.Millisecond);
        public static int numberOfShiftsInt;

        public Form1()
        {
            InitializeComponent();
            numberOfShiftsInt = Convert.ToInt32(numberOfShifts.Value);
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
            decimal minTeams = Convert.ToDecimal(label6.Text) / numberOfShifts.Value;
            minTeamsForFullSchedule.Text = "" + Math.Ceiling(minTeams);
            Array.Resize(ref bufferDateList, dates.Count);
        }

        private void addTeam_Click(object sender, EventArgs e)
        {
            if (teamName.Text.Length < 1)
            { MessageBox.Show("A team needs a name"); }
            else
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
        }

        private void teamList_SelectedIndexChanged(object sender, EventArgs e)//Highlight dates for the team. 
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
                            string buf = dateList.Items[j].ToString();
                            if (buf.Substring(0, 10) == ny.dates[k])
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
            if (teamName.Text == "")
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
            if (priorityFriday.Checked == true)//Check if the priority is different than regular
                Methods.changePriority("Friday");
            else if (priorityTuesday.Checked == true)
                Methods.changePriority("Tuesday");

            //Here we check who can take the shifts. So far it is only to get a count on each date

            for (int i = 0; i < dates.Count; i++)
            {
                bufferDateList[i] = new List<string>();
                for (int j = 0; j < teams.Count; j++)
                {
                    Team ny = teams[j];
                    bool flag = false;
                    for (int k = 0; k < ny.dates.Count; k++)
                    {
                        if (ny.dates[k] == dates[i].ToString().Substring(0, 10))
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (flag == false)
                    {
                        string name = ny.name;
                        bufferDateList[i].Add(name);
                    }
                }
            }
            // //remove this to check the other code

            //Here we find the dates that only 1 or 2 teams can take, and get them filled first and put them on an exception list for later. We might do 3 teams, but it's undicided
            for (int i = 0; i < dates.Count; i++)
            {
                if (bufferDateList[i].Count < 2)
                {
                    for (int k = 0; k < teams.Count; k++)
                    {
                        if (teams[k].name == bufferDateList[i].First().ToString())
                        {
                            teams[k].shift++;
                            finalDates.Add("" + dates[i] + " " + teams[k].name);
                            datesExeption.Add(dates[i]);
                            i++;
                            break;
                        }
                    }
                }
                else if (bufferDateList[i].Count < 3)
                {
                    rnd = new Random(DateTime.Now.Millisecond + finalDates.Count);
                    int localTeam = rnd.Next(0, bufferDateList[i].Count);
                    int modifyingTeam = Methods.findTeamName(bufferDateList[i][localTeam].ToString());
                    Team ny = teams[modifyingTeam];
                    if (ny.shift < numberOfShifts.Value)
                    {
                        teams[modifyingTeam].shift++;
                        finalDates.Add("" + dates[i] + " " + teams[modifyingTeam].name);
                        datesExeption.Add(dates[i]);
                        i++;
                    }
                }
            }
            //previous this was part of the for-loop above. Now we need to set it apart, to get the date list filled better
            Methods.createList();
            if (finalDates.Count < dateList.Items.Count)//we want a complete list. If the list is not totally filled, we try again 3 maybe 5 times (this should be tested)
            {
                List<string> finalBuffer1 = finalDates;
            }


            //This is where the two "selection algorithms" split

            /*
            //This code can create the list, but will not consider if people have 1 shift in the beggining, but cannot take one at the end
            for (int i = 0; i < dates.Count;)
            {
                rnd = new Random(DateTime.Now.Millisecond + finalListBox.Items.Count);
                int localTeam = rnd.Next(0, teamList.Items.Count);
                if (teamsTried.Sum() == teamSum(teams.Count - 1))
                {
                    i++;
                }
                else if (teamsTried[localTeam] != localTeam)//Have we tried this team already? If yes, move on. If not, try it
                {
                    teamsTried[localTeam] = localTeam;

                    if (localTeam != prevSelect && localTeam != prev2Select)//Has this team been used in the last two shifts?
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
                                //listBox1.Items.Add(dates[i] + " " + ny.name);
                                finalDates.Add("" + dates[i] + " " + ny.name);
                                i++;
                                for (int k = 0; k < teamsTried.Length; k++)
                                {
                                    teamsTried[k] = 0;
                                }
                            }
                        }
                    }
                }
            }*/

            //This is where the list is sorted and written in the box
            dates.Sort();
            string[] finalDateTeamList = new string[finalDates.Count];
            for (int i = 0; i < dates.Count; i++)
            {
                for (int j = 0; j < finalDates.Count; j++)
                {
                    string buffer = finalDates[j].ToString();
                    string buffer2 = dates[i].ToString();
                    if (buffer.Substring(0, 10) == buffer2.Substring(0, 10))
                    {
                        finalListBox.Items.Add(buffer);
                    }
                }
            }
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Public\Nymappe\list.txt"))
            {
                for (int i = 0; i < finalListBox.Items.Count; i++)
                {
                    file.WriteLine(finalListBox.Items[i]);
                }
            }
        }

        private void numberOfShifts_ValueChanged(object sender, EventArgs e)//Funktion to keep the minimum shift a positive number and recalculate the minimum needed teams
        {
            if (numberOfShifts.Value < 1)
                numberOfShifts.Value = 1;
            decimal minTeams = Convert.ToDecimal(label6.Text) / numberOfShifts.Value;
            minTeamsForFullSchedule.Text = "" + Math.Ceiling(minTeams);
            numberOfShiftsInt = Convert.ToInt32(numberOfShifts.Value);
        }

        private void deleteTeam_Click(object sender, EventArgs e)//deletes a team. NEED a fix for emptying the list
        {
            int teamSelected = teamList.SelectedIndex;
            if (teamSelected == 0)
                teamList.SetSelected(1, true);
            else
                teamList.SetSelected(0, true);
            string teamtest = teamList.Items[teamSelected].ToString();
            int test = Methods.findTeamName(teamtest);
            teams.RemoveAt(test);
            teamList.Items.RemoveAt(teamSelected);

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

        private void editTeamsButton_Click(object sender, EventArgs e)
        {
            List<String> dates = new List<String>();
            for (int i = 0; i < dateList.Items.Count; i++)
            {
                if (dateList.GetSelected(i))
                {
                    dates.Add(dateList.Items[i].ToString().Substring(0, 10));
                }
            }
            string test = teamList.SelectedItem.ToString();
            int testint = Methods.findTeamName(teamList.SelectedItem.ToString());
            teams[testint].dates = dates;
        }
    }
}
