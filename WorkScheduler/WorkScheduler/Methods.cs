using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkScheduler
{
    class Methods
    {
       static Random rnd = new Random(DateTime.Now.Millisecond);
        public static int prevSelect, prev2Select;
        public static int teamSum2(List<string> list)
        {
            int send = 0;
            for (int i = 0; i < list.Count; i++)
            {
                string buffer = list[i].ToString().Substring(4);
                send += Convert.ToInt32(buffer);
            }
            send -= list.Count;
            return send;
        }
        public static int findTeamName(string name)
        {
            for (int i = 0; i < Form1.teams.Count; i++)
            {
                if (name == Form1.teams[i].name)
                    return i;
            }
            return -1;
        }
        public static void changePriority(string priority)//Method for changeing the priority of the list, if necesary
        {
            //finalListBox.Items.Clear();//Clear the final list, so there is no old data
                                       //Split the list in tuesdays and fridays, so we can priorytise
            List<DateTime> tuesdays = new List<DateTime>();
            List<DateTime> fridays = new List<DateTime>();
            for (int i = 0; i < Form1.dates.Count; i++)
            {
                if (Form1.dates[i].DayOfWeek.ToString() == "Friday")
                {
                    fridays.Add(Form1.dates[i]);
                }
                if (Form1.dates[i].DayOfWeek.ToString() == "Tuesday")
                {
                    tuesdays.Add(Form1.dates[i]);
                }
            }
            if (priority=="Friday")//If friday is set for priority, put fridays on the top of the list
            {
                Form1.dates.Clear();
                Form1.dates.AddRange(fridays);
                Form1.dates.AddRange(tuesdays);
            }
            else if (priority == "Tuesday")//tuesday priority
            {
                Form1.dates.Clear();
                Form1.dates.AddRange(tuesdays);
                Form1.dates.AddRange(fridays);
            }
        }
        
        public static void createList()
        {
            Form1.finalDates.Clear();
            int[] teamsTried = new int[Form1.teams.Count]; //Two arrays so we can se which teams we have tried
            int[] teamsTried2 = new int[Form1.teams.Count];
            for (int i = 0; i < Form1.dates.Count;)
            {
                bool flag2 = false;
                for (int j = 0; j < Form1.datesExeption.Count; j++)//We run through the dates again, and skip them if they are on the exception list
                {
                    if (Form1.datesExeption[j] == Form1.dates[i])
                    {
                        i++;
                        flag2 = true;
                        break;
                    }
                }
                if (flag2 == false)
                {
                    rnd = new Random(DateTime.Now.Millisecond + Form1.finalDates.Count);
                    int localTeam = Form1.rnd.Next(0, Form1.bufferDateList[i].Count);
                    int modifyingTeam = findTeamName(Form1.bufferDateList[i][localTeam].ToString());
                    //localTeam = modifyingTeam;
                    if (teamsTried2.Sum() == Methods.teamSum2(Form1.bufferDateList[i]))
                    {
                        i++;
                    }
                    else if (teamsTried2[localTeam] != localTeam)//Have we tried this team already? If yes, move on. If not, try it 
                    {
                        teamsTried2[localTeam] = localTeam;
                        if (modifyingTeam != prevSelect && modifyingTeam != prev2Select)//Has this team been used in the last two shifts?
                        {
                            prev2Select = prevSelect;//updating the last two teams, who have been assigned a shift
                            prevSelect = modifyingTeam;

                            Team ny = Form1.teams[modifyingTeam];
                            if (ny.shift < Form1.numberOfShiftsInt)
                            {
                                bool flag = false;
                                for (int l = 0; l < ny.dates.Count; l++)
                                {
                                    if (Form1.dates[i].ToString() == ny.dates[l].ToString())
                                    {
                                        flag = true;
                                        break;
                                    }
                                }
                                if (flag == false)
                                {
                                    Form1.teams[modifyingTeam].shift += 1;
                                    //listBox1.Items.Add(dates[i] + " " + ny.name);
                                    Form1.finalDates.Add("" + Form1.dates[i] + " " + ny.name);
                                    i++;
                                    for (int k = 0; k < teamsTried.Length; k++)
                                    {
                                        teamsTried[k] = 0;
                                        teamsTried2[k] = 0;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
