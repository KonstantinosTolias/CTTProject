using CTTProject.Models;

namespace CTTProject.Service
{
    public interface ICRUD
    {
        public Task<List<Project>> ReadAsync();
        public Task<Project> ReadByIdAsync(int? ProjectId);


        //public Task<Project> ReadAsync(int? ProjectId);
        public Task CreateProjectAsync(Project project);
        public Task UpdateAsync(Project project);
        public Task DeleteAsync(int Id);

        public bool ProjectExist();
        public bool ProjectExists(int Id);
    }
}
