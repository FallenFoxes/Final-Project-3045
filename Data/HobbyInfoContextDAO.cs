using Final_Project_3045.Interfaces;
using Final_Project_3045.Model;

namespace Final_Project_3045.Data
{
    public class HobbyInfoContextDAO : IHobbyInfoContextDAO
    {
        private HobbyInfoContext _context;
        public HobbyInfoContextDAO(HobbyInfoContext context)
        {
            _context = context;
        }
       
        public int? Add(HobbyInfo hobby)
        {
            var hobbys = _context.Hobbys.Where(x => x.Outside.Equals(hobby.Outside)).FirstOrDefault();

            if (hobby == null)
                return null;

            try
            {
                _context.Hobbys.Add(hobby);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<HobbyInfo> GetAllHobby()
        {
            return _context.Hobbys.ToList();
        }

        public HobbyInfo GetHobbyById(int id)
        {
            return _context.Hobbys.Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public int? RemoveHobbyById(int id)
        {
            var hobby = this.GetHobbyById(id);
            if (hobby == null) return null;
            try
            {
                _context.Hobbys.Remove(hobby);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int? UpdateHobby(HobbyInfo hobby)
        {
            var hobbyToUpdate = this.GetHobbyById(hobby.Id);

            if (hobbyToUpdate == null)
                return null;

            hobbyToUpdate.Id = hobby.Id;
            hobbyToUpdate.Outside = hobby.Outside;
            hobbyToUpdate.Indoor = hobby.Indoor;
            hobbyToUpdate.Travel = hobby.Travel;
            hobbyToUpdate.Night = hobby.Night;
            hobbyToUpdate.Weekend = hobby.Weekend;

            try
            {
                _context.Hobbys.Update(hobbyToUpdate);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
