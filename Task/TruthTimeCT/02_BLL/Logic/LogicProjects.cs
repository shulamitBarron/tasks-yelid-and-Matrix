using _00_DAL;
using _01_BOL;
using _01_BOL.HelpDepartment;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace _02_BLL
{
    public class LogicProjects
    {
        //return all projects
        public static List<Project> GetAllProjects()
        {
            string query = $"SELECT * FROM truth_time_ct.Projects";

            Func<MySqlDataReader, List<Project>> func = (reader) =>
            {
                List<Project> Projects = new List<Project>();
                while (reader.Read())
                {
                    Projects.Add(new Project
                    {
                        IdProject = (int)reader[0],
                        ProjectName = (string)reader[1],
                        ClientName = (string)reader[2],
                        IdTeamLeader = (int)reader[3],
                        StartDate = (DateTime)reader[4],
                        EndDate = (DateTime)reader[5],
                        HoursForDevelopers = (double)reader[6],
                        HoursForQA = (double)reader[7],
                        HoursForUI_UX = (double)reader[8],
                        Active = reader.GetBoolean(9)

                    });
                }
                return Projects;
            };

            return DBUse.RunReader(query, func);
        }
        //return project name by idProject
        public static string GetProjectName(int id)
        {
            string query = $"SELECT projectName FROM truth_time_ct.projects WHERE idProject={id}";
            return DBUse.RunScalar(query).ToString();
        }
        //return project id by nameProject
        public static string GetProjectId(string name)
        {
            string query = $"SELECT idProject FROM truth_time_ct.projects WHERE projectName='{name}'";
            return DBUse.RunScalar(query).ToString();
        }
        //remove project by id
        public static bool RemoveProject(int id)
        {
            string query = $"DELETE FROM truth_time_ct.projects WHERE idProject={id}";
            return DBUse.RunNonQuery(query) == 1;
        }
        //update project
        public static bool UpdateProject(Project project)
        {
            string query = $"UPDATE truth_time_ct.projects SET projectName='{project.ProjectName}'," +
                $"idTeamLeader={project.IdTeamLeader},active={project.Active},startDate='{project.StartDate}',endDate='{project.EndDate}',hoursForDevelopers={project.HoursForDevelopers},hoursForQA={project.HoursForQA},hoursForUI_UX={project.HoursForUI_UX},clientName={project.ClientName} WHERE idProject = {project.IdProject}";
            return DBUse.RunNonQuery(query) == 1;
        }
        //add project
        public static bool AddProject(Project project)
        {
            bool isWorked = false;
            string query = $"INSERT INTO truth_time_ct.projects VALUES (0,'{project.ProjectName}','{project.ClientName}',{project.IdTeamLeader},'{project.StartDate}','{project.EndDate}',{project.HoursForDevelopers},{project.HoursForQA},{project.HoursForUI_UX},{project.Active})";
            isWorked = DBUse.RunNonQuery(query) == 1;
            if (isWorked)
            {
                int idProject = int.Parse(GetProjectId(project.ProjectName));
                LogicUserProject.CreateUsersProjectList(idProject, project.IdTeamLeader);
            }
            return isWorked;
        }
        //return all projects under teamLeader
        public static List<Project> GetProjectsUnderTheDirectionOfTheTeamLeader(int IdTeamLeader)
        {
            //select all projects by connect projects to userProject to users when the project under teamLeader
            string query = $"SELECT DISTINCT p.* FROM truth_time_ct.projects p JOIN truth_time_ct.users_projects up ON p.idProject=up.idProject" +
                $" JOIN truth_time_ct.users u ON u.idUser=up.idUser WHERE u.idTeamLeader={IdTeamLeader}";
            Func<MySqlDataReader, List<Project>> func = (reader) =>
            {
                List<Project> Projects = new List<Project>();
                while (reader.Read())
                {
                    Projects.Add(new Project
                    {
                        IdProject = (int)reader[0],
                        ProjectName = (string)reader[1],
                        ClientName = (string)reader[2],
                        IdTeamLeader = (int)reader[3],
                        StartDate = (DateTime)reader[4],
                        EndDate = (DateTime)reader[5],
                        HoursForDevelopers = (double)reader[6],
                        HoursForQA = (double)reader[7],
                        HoursForUI_UX = (double)reader[8],
                        Active = reader.GetBoolean(9)

                    });
                }
                return Projects;
            };

            return DBUse.RunReader(query, func);
        }
        //return idProject by namProject
        public static Project GetProjectByNameProject(string projecName)
        {
            string query = $"SELECT * FROM truth_time_ct.projects WHERE projectName='{projecName}'";
            Func<MySqlDataReader, List<Project>> func = (reader) =>
             {
                 List<Project> Projects = new List<Project>();
                 while (reader.Read())
                 {
                     Projects.Add(new Project
                     {
                         IdProject = (int)reader[0],
                         ProjectName = (string)reader[1],
                         ClientName = (string)reader[2],
                         IdTeamLeader = (int)reader[3],
                         StartDate = (DateTime)reader[4],
                         EndDate = (DateTime)reader[5],
                         HoursForDevelopers = (double)reader[6],
                         HoursForQA = (double)reader[7],
                         HoursForUI_UX = (double)reader[8],
                         Active = reader.GetBoolean(9)

                     });
                 }
                 return Projects;
             };
            Project myProject = DBUse.RunReader(query, func)[0];
            return myProject;
        }
        //return project by id project
        public static Project GetProjectByIdProject(int idProject)
        {
            string query = $"SELECT * FROM truth_time_ct.projects WHERE idProject={idProject}";
            Func<MySqlDataReader, List<Project>> func = (reader) =>
            {
                List<Project> Projects = new List<Project>();
                while (reader.Read())
                {
                    Projects.Add(new Project
                    {
                        IdProject = (int)reader[0],
                        ProjectName = (string)reader[1],
                        ClientName = (string)reader[2],
                        IdTeamLeader = (int)reader[3],
                        StartDate = (DateTime)reader[4],
                        EndDate = (DateTime)reader[5],
                        HoursForDevelopers = (double)reader[6],
                        HoursForQA = (double)reader[7],
                        HoursForUI_UX = (double)reader[8],
                        Active = reader.GetBoolean(9)

                    });
                }
                return Projects;
            };
            Project myProject = DBUse.RunReader(query, func)[0];
            return myProject;
        }
        //return hours that defined for project
        public static int GetHoursOfProject(int idProject)
        {
            string query = $"SELECT hoursForProject FROM truth_time_ct.projects WHERE idProject={idProject}";
            return int.Parse(DBUse.RunScalar(query).ToString());
        }
        //return how many hours the users worked on spesipic project             
        public static int GetHoursThatWorkedOfProject(int idProject)
        {
            //get the hours by dateDiff between start and end date
            string query = $"SELECT sum(SELECT DATEDIFF(hour, startDatePresence, endDatePresence) FROM truth_time_ct.daily_presence WHERE idProject={idProject}) from truth_time_ct.daily_presence";
            return int.Parse(DBUse.RunScalar(query).ToString());
        }
        //why not * up.idUserProject,up.hoursProjectUser,up.idUser,up.idProject
        //return dictionary of userProject and the hours that the user worked to this userProject; 
        public static Dictionary<UserProject, double> GetDictionaryOfHoursThatUserWorkedOnProjectInPrecent(int idUser)
        {
            //for user select all data of userProjects of him with the time that he worked for that project;
            string query = $"SELECT *,sum(SELECT DATEDIFF(hour, startDatePresence, endDatePresence) FROM truth_time_ct.daily_presence WHERE idProject=up.idProject and idUser={idUser}) from truth_time_ct.users_projects up WHERE up.idUser={idUser} Group By up.idUserProject,up.hoursProjectUser,up.idUser,up.idProject";
            Func<MySqlDataReader, Dictionary<UserProject, double>> func = (reader) =>
            {
                Dictionary<UserProject, double> myDictionary = new Dictionary<UserProject, double>();
                while (reader.Read())
                {
                    myDictionary.Add(new UserProject
                    {
                        IdUserProject = (int)reader[0],
                        HoursProjectUser = (int)reader[1],
                        IdUser = (int)reader[2],
                        IdProject = (int)reader[3]
                    }, (int)reader[4]);
                }
                return myDictionary;
            };

            return DBUse.RunReaderDictionary(query, func);
        }
        //sum hours that user worked on spesipic project on specipic month
        public static int SumHoursUserWorkedProjectOnSpecipicMonth(int idProject, int idUser, int? month)
        {
            string myMonth = DateTime.Now.Month.ToString();
            if (month != null)//or hasValue
                myMonth = month.ToString();
            string query = $"SELECT sum(SELECT DATEDIFF(hour, startDatePresence, endDatePresence) FROM truth_time_ct.daily_presence WHERE idProject={idProject} and idUser={idUser} and MONTH(startDatePresence)=myMonth)";
            return int.Parse(DBUse.RunScalar(query).ToString());
        }
        //return the hours that users worked on that project;
        public static int GetHoursThatWorkedOnProject(int idProject)
        {
            string query = $"SELECT sum(SELECT DATEDIFF(hour, startDatePresence, endDatePresence) FROM truth_time_ct.daily_presence WHERE idProject={idProject})";
            return int.Parse(DBUse.RunScalar(query).ToString());
        }
        //get dictionary of days and the hours that users worked in this day on any project
        public static Dictionary<string, double> GetHoursWorkedOnProjectByDays(int idProject, int month)
        {
            //select days and for every day the sum of hours that the users worked on specipic project on specipic month
            string query = $"SELECT DAY(d.startDatePresence),sum(SELECT DATEDIFF(hour,startDatePresence,endDatePresence) FROM truth_time_ct.daily_presence d WHERE idProject={idProject} and month(startDatePresence)={month} group by(DAY(startDatePresence))) ";

            Func<MySqlDataReader, Dictionary<string, double>> func = (reader) =>
              {
                  Dictionary<string, double> DailySupply = new Dictionary<string, double>();
                  while (reader.Read())
                  {
                      DailySupply.Add(
                          (string)reader[0],
                          (double)reader[1]);

                  }
                  return DailySupply;
              };

            return DBUse.RunReaderDictionary(query, func);
        }
        //get dictionary of users and hours that worked
        public static Dictionary<UserProject, double> GetUsersAndHoursThatWorkedOnProject(int idProject)
        {

            List<User> UsersOfProject = LogicUsers.GetUsersOfProject(idProject);
            Dictionary<UserProject, double> UsersAndHoursWorkedOnProject = new Dictionary<UserProject, double>();
            foreach (User user in UsersOfProject)
            {
                UserProject userProject = LogicUserProject.GetSpesipicUserProject(user.IdUser, idProject);
                UsersAndHoursWorkedOnProject.Add(userProject, GetDictionaryOfHoursThatUserWorkedOnProjectInPrecent(user.IdUser)[userProject]);
            }
            return UsersAndHoursWorkedOnProject;
        }
        //graf of status hours that updated by users on all their projects by getting the teamLeader
        public static Dictionary<User, ObjectOfHours> GetUsersAndHoursThatUsersWorkedUnderTheirTeamLeader(int idTeamLeader)
        {
            List<User> UsersUnderTeamLeader = LogicUsers.GetAllUsersUnderTeamLeader(idTeamLeader);
            Dictionary<User, ObjectOfHours> TheUsersAndTheTimeThatWorked = new Dictionary<User, ObjectOfHours>();
            double sumHoursuserWorked = 0, sumHoursuserHadToWorked = 0;
            foreach (User user in UsersUnderTeamLeader)
            {
                sumHoursuserWorked = 0;
                sumHoursuserHadToWorked = 0;
                foreach (var item in GetDictionaryOfHoursThatUserWorkedOnProjectInPrecent(user.IdUser))
                {
                    sumHoursuserWorked += item.Value;
                    sumHoursuserHadToWorked += item.Key.HoursProjectUser;
                }
                TheUsersAndTheTimeThatWorked.Add(user, new ObjectOfHours() { sumHoursuserHadToWorked = sumHoursuserHadToWorked, sumHoursuserWorked = sumHoursuserWorked });
            }
            return TheUsersAndTheTimeThatWorked;
        }
        //return all projects under specipic teamLeader
        public static List<Project> GetProjectsUnderTeamLeader(int idTeamLeader)
        {
            string query = $"SELECT * FROM truth_time_ct.Projects WHERE idTeamLeader={idTeamLeader}";

            Func<MySqlDataReader, List<Project>> func = (reader) =>
            {
                List<Project> Projects = new List<Project>();
                while (reader.Read())
                {
                    Projects.Add(new Project
                    {
                        IdProject = (int)reader[0],
                        ProjectName = (string)reader[1],
                        ClientName = (string)reader[2],
                        IdTeamLeader = (int)reader[3],
                        StartDate = (DateTime)reader[4],
                        EndDate = (DateTime)reader[5],
                        HoursForDevelopers = (double)reader[6],
                        HoursForQA = (double)reader[7],
                        HoursForUI_UX = (double)reader[8],
                        Active = reader.GetBoolean(9)

                    });
                }
                return Projects;
            };
            return DBUse.RunReader(query, func);
        }
        //get all data on projects
        public static Dictionary<ProjectObject, List<UserObject>> GetAllDataOnProject(int idProject)
        {
            List<User> UsersUnderSpecipicProject = LogicUsers.GetUsersOfProject(idProject);
            List<UserObject> userObjects = new List<UserObject>();
            Project project = GetProjectByIdProject(idProject);
            ProjectObject projectObject = new ProjectObject() { ProjectObjectHoursAllocatedProject = project.HoursForDevelopers + project.HoursForQA + project.HoursForUI_UX, ProjectObjectName = project.ProjectName };
            UserObject userObject = new UserObject();
            Dictionary<ProjectObject, List<UserObject>> allDataOnSpecipicProject = new Dictionary<ProjectObject, List<UserObject>>();
            foreach (var item in GetUsersAndHoursThatWorkedOnProject(idProject))
            {
                userObject.UserObjectName = UsersUnderSpecipicProject.Find(p => p.IdUser == item.Key.IdUser).UserName;
                userObject.UserObjectSumHours = item.Value;
                userObject.UserObjectHoursAllocatedProject = item.Key.HoursProjectUser;
                userObjects.Add(userObject);
            }
            allDataOnSpecipicProject.Add(projectObject, userObjects);
            return allDataOnSpecipicProject;
        }
    }

}
