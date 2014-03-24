using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Quartz;
using Quartz.Impl;
using RecipiesModelNS;
using RecipiesWebFormApp.Quartz.Jobs;

namespace RecipiesWebFormApp.Quartz.ActionsForScheduling
{
    public static class ActionsForScheduling
    {
        private static ISchedulerFactory schedFact;
        private static IScheduler sched;

        private static SqlConnection sqlConn;
        private static SqlCommand command;

        static ActionsForScheduling()
        {
            sqlConn = new SqlConnection(ContextFactory.Current.Database.Connection.ConnectionString);
            command = new SqlCommand();
            command.Connection = sqlConn;

            // construct a scheduler factory
            schedFact = new StdSchedulerFactory();

            // get a scheduler
            sched = schedFact.GetScheduler();
            sched.Start();
        }

        public static void StartAll()
        {
            UpdateUnitPriceOfProductsAction();
            CalculateRecipesProductionValuePerPortionAction(); // this must be after UpdateUnitPriceOfProductsAction
            CheckDatabaseForChangesAction();
            RefreshWebsiteAction();
        }

        public static void UpdateUnitPriceOfProductsAction()
        {
            IJobDetail job = JobBuilder.Create<CalculateProductsUnitPriceJob>()
                .WithIdentity("UpdateUnitPriceOfProductsAction", "group1")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("myTrigger", "group1")
                //.StartNow()
                  .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(1, 1))
                .Build();

            sched.ScheduleJob(job, trigger);
        }

        public static void CheckDatabaseForChangesAction()
        {

            IJobDetail job = JobBuilder.Create<CheckDatabaseForChangesJob>()
                .WithIdentity("CheckDatanaseForChangesAction", "group1")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("myTrigger2", "group2")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(1)
                    .RepeatForever())
                .Build();

            sched.ScheduleJob(job, trigger);
        }
        public static void RefreshWebsiteAction()
        {
            IJobDetail job = JobBuilder.Create<CalculateProductsUnitPriceJob>()
                .WithIdentity("RefreshWebsiteAction", "group3")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("myTrigger3", "group3")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInMinutes(10)
                    .RepeatForever())
                .Build();

            sched.ScheduleJob(job, trigger);
        }


        public static void CalculateRecipesProductionValuePerPortionAction()
        {
            IJobDetail job = JobBuilder.Create<CalculateRecipesProductionValuePerPortionJob>()
                .WithIdentity("CalculateRecipesProductionValuePerPortionJob", "group4")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("myTrigger4", "group4")
                //.StartNow()
                  .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(1, 1))
                .Build();

            sched.ScheduleJob(job, trigger);
        }

    }
}