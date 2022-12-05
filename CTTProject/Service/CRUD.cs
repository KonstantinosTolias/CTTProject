using Microsoft.EntityFrameworkCore;
using CTTProject.Service;
using CTTProject.Migrations;
using CTTProject.Models;

namespace CTTProject.Service

{
    public class CRUD : ICRUD
    {
        private readonly ProjectDb _context;
        public CRUD(ProjectDb context)
        {
            _context = context;
        }

        public async Task<List<Project>> ReadAsync()
        {
            return await _context.Projects.ToListAsync();
        }
        public async Task<Project> ReadAsync(int? ProjectId) =>
            await _context
                 .Projects
                 .Include(Project => Project.Id)
                 .FirstAsync(p => p.Id == ProjectId);

        public async Task CreateProjectAsync(Project project)
        {
            _context.Add(project);

            await _context.SaveChangesAsync();


        }

        public async Task UpdateAsync(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();

        }
        public async Task DeleteAsync(int id)
        {
            var project = await ReadAsync(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
            }

            await _context.SaveChangesAsync();
        }


        public bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }

        public bool ProjectExist()
        {
            return _context.Projects == null;
        }

        public async Task<List<Project>> ReadByIdAsync(int? projectId)
        {
            return await _context
                .Projects
                .Where(project => project.Id == projectId)
                .ToListAsync();
        }

    }
}
