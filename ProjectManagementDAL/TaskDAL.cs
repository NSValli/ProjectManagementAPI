using AutoMapper;
using ProjectManagementDAL.Entities;
using ProjectManagementDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = ProjectManagementDAL.Models.Task;
using TaskEntity = ProjectManagementDAL.Entities.Task;
using ParentTask = ProjectManagementDAL.Models.ParentTask;
using ParentEntity = ProjectManagementDAL.Entities.ParentTask;

namespace ProjectManagementDAL
{
    public class TaskDAL
    {
        MapperConfiguration mapperConfig;
        public  TaskDAL()
        {
            //Initialize the mapper
            mapperConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<Task, TaskEntity>();
                cfg.CreateMap<TaskEntity,Task>();
                cfg.CreateMap<ParentTask, ParentEntity>();
                cfg.CreateMap<ParentEntity, ParentTask>();
            });
        }
        public List<Task> GetAllTask()
        {
            ProjectManagementContext taskContext = new ProjectManagementContext();
            var taskDetails = (from task in taskContext.Tasks
                               join parentTask in taskContext.ParentTasks
                               on task.ParentId  equals parentTask.ParentId
                               join project in taskContext.Projects
                               on task.ProjectId equals project.ProjectID
                               join user in taskContext.Users
                               on task.UserID equals user.UserID
                               select new Task
                               {
                                   TaskId = task.TaskId,
                                   TaskName = task.TaskName,
                                   ParentId = task.ParentId,
                                   ParentTaskName = parentTask.TaskName,
                                   ProjectId = task.ProjectId,
                                   ProjectName = project.ProjectName,
                                   UserId = task.UserID,
                                   UserName = user.FirstName+" "+user.LastName,
                                   Priority = task.Priority,
                                   Status = task.Status,
                                   StartDate = task.StartDate,
                                   EndDate = task.EndDate
                                });
                        
            return taskDetails.ToList();
        }

        public Task GetTask(int taskId)
        {
            ProjectManagementContext taskContext = new ProjectManagementContext();
            var task = taskContext.Tasks
             .SingleOrDefault(x => x.TaskId == taskId);
            var mapper = new Mapper(mapperConfig);
            var taskDetails = mapper.Map<Task>(task);
            return taskDetails;
        }

        public void CreateTask(Task task)
        {
            ProjectManagementContext taskContext = new ProjectManagementContext();
            var mapper = new Mapper(mapperConfig);
            var taskEntity = mapper.Map<TaskEntity>(task);
            taskContext.Tasks.Add(taskEntity);
            taskContext.SaveChanges();
        }    

        public void UpdateTask(Task task)
        {
            ProjectManagementContext taskContext = new ProjectManagementContext();
            var taskData = taskContext.Tasks.Find(task.TaskId);
            if (taskData != null)
            { 
                taskData.TaskName = task.TaskName;
                taskData.StartDate = task.StartDate;
                taskData.EndDate = task.EndDate;
                taskData.Priority = task.Priority;
                taskData.Status = task.Status;
                taskData.UserID = task.UserId;
                taskContext.SaveChanges();
            }
        }

        public void DeleteTask(int TaskId)
        {
            ProjectManagementContext taskContext = new ProjectManagementContext();
            var task = taskContext.Tasks
             .SingleOrDefault(up => up.TaskId == TaskId);
            taskContext.Tasks.Remove(task);
            taskContext.SaveChanges();
        }

        public void CreateParentTask(ParentTask parentTask)
        {
            ProjectManagementContext taskContext = new ProjectManagementContext();
            var mapper = new Mapper(mapperConfig);
            var parentEntity = mapper.Map<ParentEntity>(parentTask);          
            taskContext.ParentTasks.Add(parentEntity);
            taskContext.SaveChanges();
        }

        public List<ParentTask> GetAllParentTask()
        {
            ProjectManagementContext TaskContext = new ProjectManagementContext();
            var parentTasks = (from s in TaskContext.ParentTasks
                         orderby s.TaskName
                         select s);
            var mapper = new Mapper(mapperConfig);
            var parentTaskDetails = mapper.Map<List<ParentTask>>(parentTasks);
            return parentTaskDetails;    
        }        

    }
}
