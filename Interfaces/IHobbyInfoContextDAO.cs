using Final_Project_3045.Model;

namespace Final_Project_3045.Interfaces
{
    public interface IHobbyInfoContextDAO
    {
        List<HobbyInfo> GetAllHobby();
        HobbyInfo GetHobbyById(int hobbyId);
        int? RemoveHobbyById(int id);
        int? UpdateHobby(HobbyInfo hobby);
        int? Add(HobbyInfo hobby);

    }
}
