using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Data_Access.Models
{

    public class ActivityLog
    {
        public int ActivityID { get; set; } // Primary Key
        public string TableName { get; set; } // Name of the table being modified
        public int RecordID { get; set; } // ID of the record being modified
        public string ActionType { get; set; } // Type of action (INSERT, UPDATE, DELETE)
        public DateTime? ActionTimestamp { get; set; } // When the action occurred (nullable)
        public string Details { get; set; } // Details about the change (nullable)
        public string UserName { get; set; } // Username of the user performing the action (nullable)

        // Constructor to initialize the object
        public ActivityLog()
        {
            // Default constructor
        }

        // Overloaded constructor for easier object creation
        public ActivityLog(int activityID, string tableName, int recordID, string actionType, DateTime? actionTimestamp, string details, string userName)
        {
            ActivityID = activityID;
            TableName = tableName;
            RecordID = recordID;
            ActionType = actionType;
            ActionTimestamp = actionTimestamp;
            Details = details;
            UserName = userName;
        }

        // Override ToString() for easy debugging or logging
        public override string ToString()
        {
            return $"ActivityID: {ActivityID}, TableName: {TableName}, RecordID: {RecordID}, ActionType: {ActionType}, ActionTimestamp: {ActionTimestamp}, Details: {Details}, UserName: {UserName}";
        }
    }
}


