using client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.ViewModels
{
    public class SelectedFilterViewModel<T>
    {
        public T Id { get; set; } = default!;
        public string Name { get; set; } = string.Empty;
        public bool IsSelected { get; set; }

        // Проверка соответствия для списка навыков курса
        public bool IsMatch(IEnumerable<Skill>? courseSkills)
        {
            if (!IsSelected) return true; // фильтр не применён — считается совпадением
            if (courseSkills == null) return false;

            foreach (var s in courseSkills)
            {
                if (Equals(s.Id, Id))
                    return true;
            }
            return false;
        }

        // Проверка соответствия для списка профессий курса
        public bool IsMatch(IEnumerable<Profession>? courseProfessions)
        {
            if (!IsSelected) return true;
            if (courseProfessions == null) return false;

            foreach (var p in courseProfessions)
            {
                if (Equals(p.Id, Id))
                    return true;
            }
            return false;
        }
    }
}
