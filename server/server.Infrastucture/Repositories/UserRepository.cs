using Microsoft.EntityFrameworkCore;
using server.Persistence;
using server.Domain.Models;

using server.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using server.Domain.DTOs;


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

        public Task<User> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserSkills(int user_id, List<LeveledSkillDto> skills)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserProfession(int user_id, int profession_id)
        {
            throw new NotImplementedException();
        }
    }
    
}
