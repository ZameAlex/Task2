using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Models;
using Task2.QueriesDTO;

namespace Task2;
public class DataProcessor
{
    public IEnumerable<User> LinkPostsToUser(IEnumerable<User> users, IEnumerable<Post> posts)
    {
        var result = new List<User>();
        var groupedPosts = posts.GroupBy(post => post.UserId);
        foreach (var user in users)
        {
            user.Posts = groupedPosts.Where(post=>post.Key == user.Id).SelectMany(x=>x.ToList());
            foreach (var post in user.Posts)
            {
                post.User = user;
            }
            result.Add(user);
        }
        return result;
    }

    public IEnumerable<User> FilterByNameStart(IEnumerable<User> users, string start)
    {
        return users.Where(u => u.Address.City.StartsWith(start));
    }

    public IEnumerable<CountPostsByUser> PostsCountByUser(IEnumerable<User> users)
    {
        return users.Select(u => new CountPostsByUser{ UserName =  u.Name, City = u.Address?.City, PostsCount = u.Posts.Count() });
    }
    /// <summary>
    /// Show posts with body more than 170 letters, if posts count with title that have more than 40 letters more than a half of total posts.
    /// Otherwise, user will not be shown.
    /// </summary>
    /// <param name="users"></param>
    /// <returns></returns>
    public IEnumerable<CountPostsByUser> PostsMoreThan170(IEnumerable<User> users)
    {
        var x = users.Where(u => u.Posts.Count(p => p.Title.Length > 40) > u.Posts.Count() / 2).ToList();
          return x.Select(s => new CountPostsByUser
            {
                UserName = s.Name,
                City = s.Address?.City,
                PostsCount = s.Posts.Count(s => s.Body.Length > 170)
            });
    }
}
