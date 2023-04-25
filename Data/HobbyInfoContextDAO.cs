using Final_Project_3045.Interfaces;
using Final_Project_3045.Model;

namespace Final_Project_3045.Data
{
    public class InfoContextDAO : IHobbyInfoContextDAO
    {
        private HobbyInfoContext _context;
        public HobbyInfoContextDAO(HobbyInfoContext context)
        {
            _context = context;
        }
       
        public int? Add(HobbyInfo hobby)
        {
            var hobby = _context.Hobby.Where(x => x.Hobby.Equals(hobby.Hobby)).FirstOrDefault();

            if (hobby == null)
                return null;

            try
            {
                _context.Hobby.Add(hobby);
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
            return _context.Hobby.ToList();
        }

        public HobbyInfo GetHobbyById(int id)
        {
            return _context.Hobby.Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public int? RemoveHobbyById(int id)
        {
            var hobby = this.GetHobbyById(id);
            if (hobby == null) return null;
            try
            {
                _context.Hobby.Remove(hobby);
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

            hobbyToUpdate.Hobby = hobby.Hobby;
            hobbyToUpdate.Id = hobby.Id;
            hobbyToUpdate.Outside = hobby.Outside;
            hobbyToUpdate.Indoor = hobby.Indoor;
            hobbyToUpdate.Travel = hobby.Travel;
            hobbyToUpdate.Night = hobby.Night;
            hobbyToUpdate.Weekend = hobby.Weekend;

            try
            {
                _context.Hobby.Update(hobbyToUpdate);
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
