using System;
using System.Net;
using System.IO;  
//using CDO;    

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class add_calendar
	{
		public void add_cal()
		{
			try 
			{
				/*CDO.Appointment oApp = new CDO.Appointment();

				// TODO:
				string sURL = "https://ntsbs01/Exchange/b.briffa/calendar";

				ADODB.Connection oCn = new ADODB.Connection();
				oCn.Provider = "MSDAIPP.DSO";

				oCn.Open(sURL, "b.briffa", "gr1jp233", 0);  
						
				CDO.Configuration iConfg = new CDO.Configuration();
				ADODB.Fields oFields;


				oFields = iConfg.Fields;
				oFields[CDO.CdoCalendar.cdoTimeZoneIDURN].Value = CDO.CdoTimeZoneId.cdoPacific;

				// Set Meeting Organizer
				oFields[CDO.CdoConfiguration.cdoSendEmailAddress].Value = "zdu@dudomain.example.com";			
				oFields.Update();

				oApp.Configuration = iConfg;
				oApp.StartTime = Convert.ToDateTime("10/11/2001 10:00:00 AM");
				oApp.EndTime = Convert.ToDateTime("10/11/2001 11:00:00 AM");
				oApp.Location = "My Cube";
				oApp.Subject = "Test: Create Meeting in C#";
				oApp.TextBody = "Hello...";

				// Add Recurring
				// Every Thursday starting Today and run 3 times
				CDO.IRecurrencePatterns iRPatters = oApp.RecurrencePatterns;
				CDO.IRecurrencePattern iRPatter = iRPatters.Add("Add");
				iRPatter.Frequency = CDO.CdoFrequency.cdoWeekly;
				iRPatter.Interval = 1;    // 1 hour from 10 to 11
				iRPatter.DaysOfWeek.Add(4);  // every Thursday
				iRPatter.Instances = 3;

				// Add Attendees
				CDO.IAttendees iAtdees = oApp.Attendees;
				CDO.IAttendee iAtdee = iAtdees.Add("User1@dudomain.example.com");  // TODO:
			
				CDO.ICalendarMessage iCalMsg = (CDO.ICalendarMessage)oApp.CreateRequest();
				iCalMsg.Message.Send();
			

				// Save to the Events Calendar
				oApp.DataSource.SaveToContainer(sURL, null, 
					ADODB.ConnectModeEnum.adModeReadWrite, 
					ADODB.RecordCreateOptionsEnum.adCreateNonCollection, 
					ADODB.RecordOpenOptionsEnum.adOpenSource, 
					"", "");

				oCn.Close();

				oApp = null;
				oCn = null;
				oFields = null;*/
			}
			catch (Exception e)
			{
				Console.WriteLine("{0} Exception caught.", e);
			}
		}
	}

}