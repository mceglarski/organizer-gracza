using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Data
{
    public class ReminderRepository : IReminderRepository
    {
        private readonly DataContext _context;

        public ReminderRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Reminder> GetReminderById(int reminderId)
        {
            return await _context.Reminder
                .Include(u => u.User)
                .SingleOrDefaultAsync(x => x.ReminderId == reminderId);
        }

        public async Task<IEnumerable<Reminder>> GetRemindersForUserById(int userId)
        {
            return await _context.Reminder
                .Include(u => u.User)
                .Where(u => u.UserId == userId)
                .ToListAsync();
        }

        public async Task<Reminder> GetReminderForUser(int reminderId, int userId)
        {
            return await _context.Reminder
                .Include(u => u.User)
                .Where(u => u.UserId == userId)
                .SingleOrDefaultAsync(r => r.ReminderId == reminderId);
        }

        public async Task<IEnumerable<Reminder>> GetReminders()
        {
            return await _context.Reminder
                .Include(u => u.User)
                .ToListAsync();
        }

        public void AddReminder(Reminder reminder)
        {
            _context.Reminder.Add(reminder);
        }

        public void DeleteReminder(Reminder reminder)
        {
            _context.Reminder.Remove(reminder);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateReminder(Reminder reminder)
        {
            _context.Attach(reminder);
            _context.Entry(reminder).State = EntityState.Modified;
        }
    }
}