using _00_DAL;
using _01_BOL;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using _01_BOL.HelpDepartment;
using System.Linq;

namespace _02_BLL
{
    public class LogicUserProject
    {
        public static List<UserProject> GetAllUserProject()
        {
            string query = $"SELECT * FROM truth_time_ct.users_projects";

            Func<MySqlDataReader, List<UserProject>> func = (reader) =>
            {
                List<UserProject> users_projects = new List<UserProject>();
                while (reader.Read())
                {
                    users_projects.Add(new UserProject
                    {
                        IdUserProject = (int)reader[0],
                        HoursProjectUser = (int)reader[1],
                        IdProject = (int)reader[2],
                        IdUser = (int)reader[3]
                    });
                }
                return users_projects;
            };

            return DBUse.RunReader(query, func);
        }

        public static string GetHoursProjectUser(int id)
        {
            string query = $"SELECT hoursProjectUser FROM truth_time_ct.users_projects WHERE idProject={id}";
            return DBUse.RunScalar(query).ToString();
        }

        public static bool RemoveUserProject(int id)
        {
            string query = $"DELETE FROM truth_time_ct.users_projects WHERE idUserProject={id}";
            return DBUse.RunNonQuery(query) == 1;
        }
        //update hours for  userProject
        public static bool UpdateUserProject(UserProject userProject)
        {
            string query = $"UPDATE truth_time_ct.users_projects SET hoursProjectUser={userProject.HoursProjectUser} WHERE idUserProject = {userProject.IdUserProject}";
            return DBUse.RunNonQuery(query) == 1;
        }

        public static bool AddUserProject(UserProject userProject)
        {
            string query = $"INSERT INTO truth_time_ct.users_projects VALUES (0,'{userProject.HoursProjectUser}'" +
                $",{userProject.IdProject},{userProject.IdUser})";
            return DBUse.RunNonQuery(query) == 1;
        }
        public static UserProject GetSpesipicUserProject(int idUser, int idProject)
        {
            string query = $"SELECT * FROM truth_time_ct.users_projects where idUser={idUser} and idProject={idProject}";

            Func<MySqlDataReader, List<UserProject>> func = (reader) =>
             {
                 List<UserProject> UserProject = new List<UserProject>();
                 UserProject.Add(new UserProject
                 {
                     IdUserProject = (int)reader[0],
                     HoursProjectUser = (int)reader[1],
                     IdProject = (int)reader[2],
                     IdUser = (int)reader[3]
                 });
                 return UserProject;
             };

            return DBUse.RunReader(query, func)[0];
        }
        //get userProject ById
        public static UserProject GetUserProjectById(int idUserProject)
        {
            string query = $"SELECT * FROM truth_time_ct.users_projects WHERE idUserProject={idUserProject}";
            Func<MySqlDataReader, List<UserProject>> func = (reader) =>
            {
                List<UserProject> UserProjects = new List<UserProject>();
                while (reader.Read())
                {
                    UserProjects.Add(new UserProject
                    {
                        IdUserProject = (int)reader[0],
                        HoursProjectUser = (int)reader[1],
                        IdProject = (int)reader[2],
                        IdUser = (int)reader[3]
                    });
                }
                return UserProjects;
            };
            UserProject userProject = DBUse.RunReader(query, func)[0];
            return userProject;
        }
        //return all project under user()
        public static List<Project>AllProjectOfSpecipicUser(int idUser)
        {
            string query = $"SELECT * FROM truth_time_ct.Projects p join truth_time_ct.users_projects up on p.idProject=up.idProject WHERE up.idUser={idUser}";

            Func<MySqlDataReader, List<Project>> func = (reader) =>
            {
                List<Project> Projects = new List<Project>();
                while (reader.Read())
                {
                    Projects.Add(new Project
                    {
                        IdProject = (int)reader[0],
                        ProjectName = (string)reader[1],
                        IdTeamLeader = (int)reader[2],
                    });
                }
                return Projects;
            };

            return DBUse.RunReader(query, func);
        }     
        //return x days and y hours that user worked on specipic project
        public static  List<HoursOfUserProjectByDays> GetDaysAndHoursUserWorkedOnProject(int idProject,int idUser)
        {
            string query = $"SELECT  d.Day(startDatePresence),sum(SELECT DATEDIFF(hour, startDatePresence, endDatePresence)" +
                $" FROM truth_time_ct.daily_presence WHERE idProject={idProject} and idUser={idUser} and DAY(startDatePresence)=d.Day(startDatePresence)) " +
                $"from truth_time_ct.daily_presence d";
          
            Func <MySqlDataReader, List<HoursOfUserProjectByDays>> func = (reader) =>
            {
                List<HoursOfUserProjectByDays> hoursOfUserProjectByDays = new List<HoursOfUserProjectByDays>();
                while (reader.Read())
                {
                    hoursOfUserProjectByDays.Add(new HoursOfUserProjectByDays
                    {
                        Day = (string)reader[0],
                        hours=(int)reader[1]
                    });
                }
                return hoursOfUserProjectByDays;
            };

            return DBUse.RunReader(query, func);
        }
        //add usersProjects To Specipic Project
        public static void CreateUsersProjectList(int idProject, int idTeamLeader)
        {
           List<User> allUsersUnderTeamLeader= LogicUsers.GetAllUsersUnderTeamLeader(idTeamLeader);
            UserProject userProject;
            foreach (User user in allUsersUnderTeamLeader)
            {
                userProject = new UserProject() {
                    IdProject = idProject,
                    IdUser = user.IdUser,
                    HoursProjectUser = 0
                };
                AddUserProject(userProject);
            }

        }
        //return all names of users and userprojects under teamleader
        public static List<UserProjectHelp> GetAllUserProjectUnderTeamLeaderWithNames(int idTeamLeader)
        {
            string query = $"SELECT up.* FROM truth_time_ct.users_projects up join truth_time_ct.projects p on up.idProject=p.idProject and p.idTeamLeader={idTeamLeader} where p.active=true;";
            List<User> allUsersUnderTeamLeader = LogicUsers.GetAllUsersUnderTeamLeader(idTeamLeader);
            List<Project> allProjectUnderTeamLeader = LogicProjects.GetProjectsUnderTeamLeader(idTeamLeader);
            Func<MySqlDataReader, List<UserProjectHelp>> func = (reader) =>
            {
                List<UserProjectHelp> users_projects_help = new List<UserProjectHelp>();
                while (reader.Read())
                {
                    users_projects_help.Add(new UserProjectHelp
                    {
                        IdUserProject = (int)reader[0],
                        HoursProjectUser = (int)reader[1],
                        IdProject = (int)reader[2],
                        IdUser = (int)reader[3],
                        NameProject = allProjectUnderTeamLeader.FirstOrDefault(p => p.IdProject == (int)reader[2]).ProjectName,
                        NameUser = allUsersUnderTeamLeader.FirstOrDefault(p => p.IdUser == (int)reader[3]).UserName
                    });
                }
                return users_projects_help;
            };

            return DBUse.RunReader(query, func);
        }
        //set all hours of usersProjects
        public static bool SetAllUsersProjects(List<UserProject> userProjectForEdit)
        {
            foreach (UserProject userProject in userProjectForEdit)
            {
                if (!UpdateUserProject(userProject))
                    return false;
            }
            return true;
        }
    }
}
