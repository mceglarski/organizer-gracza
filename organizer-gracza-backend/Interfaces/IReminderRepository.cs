using System.Collections.Generic;
using System.Threading.Tasks;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Interfaces
{
    public interface IReminderRepository
    {
        Task<Reminder> GetReminderById(int reminderId);
        Task<IEnumerable<Reminder>> GetRemindersForUserById(int userId);
        Task<Reminder> GetReminderForUser(int reminderId, int userId);
        Task<Reminder> GetReminderByNameForUser(string title, int userId);
        Task<IEnumerable<Reminder>> GetReminders();
        void AddReminder(Reminder reminder);
        void DeleteReminder(Reminder reminder);
        Task<bool> SaveAllAsync();
        void UpdateReminder(Reminder reminder);

    }
}