using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using server.Persistence;
using server.Domain.Models;
using System.Runtime.Intrinsics.X86;
using server.Domain.Interfaces.Repositories;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Storage.Internal;

namespace server.Infrastucture.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) { 
            _context = context; 
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<bool> UserExist(Guid id)
        {
            return await _context.User.AnyAsync(us => us.Id == id);
        }
        public async Task<bool> UserExist(string login)
        {
            return await _context.User.AnyAsync(us => us.Login == login);
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await _context.User.FindAsync(id);
        }
        public async Task<User> GetUserByLogin(string login)
        {
            return await _context.User.FindAsync(login);
        }

        public async Task<List<LeveledSkill>> GetUserSkills(int id)
        {
            return _context.User.FindAsync(id).Result.SkillsHave;
        }
        public async Task<List<CourseTaken>> GetUserCourses(int id)
        {
            return _context.User.FindAsync(id).Result.CoursesTaken;
        }
        public async Task<Profession> GetUserProfession(int id)
        {
            return _context.User.FindAsync(id).Result.ProfessionChosen;
        }
        public async Task UpdateUserSkills(int user_id, List<LeveledSkill> skills)
        {
            
            for (int i = 0; i < skills.Count; i++) {
                var skill = skills[i];
                if(_context.User.FindAsync(user_id).Result.SkillsHave.ElementAt(i).Level == skill.Level)
                {
                   if( _context.User.FindAsync(user_id).Result.SkillsHave.ElementAt(i).Level < skill.Level)
                    {
                        _context.User.FindAsync(user_id).Result.SkillsHave.ElementAt(i).Level = skill.Level;
                    }
                        
                }
                else {
                    _context.User.FindAsync(user_id).Result.SkillsHave.Append(skill);
                }
            }
        }
        public async Task UpdateUserCourseProgress(int user_id, int course_id, double progress)
        {
            _context.User.FindAsync(user_id).Result.CoursesTaken.ElementAt(course_id).Progress = progress;
        }

    }
    
}
