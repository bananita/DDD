using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Model.Delivery;
using Core.Domain.Model.RepositoryInterfaces;

namespace Core.Infrastructure.Repository
{
    public class ClientRepository : IClientRepository
    {
        public void InsertClient(Client client)
        {

        }
        public void UpdateClient(Client client)
        {

        }
        public void DeleteClient(Client client)
        {

        }
        public Client RetrieveClient(int id)
        {
            return null;
        }
        public ICollection<Client> RetrieveAllClients()
        {
            return null;
        }
        public void AddOrder(int ClientId, Order order)
        {

        }
     /*   private List<Post> posts = new List<Post>();

        public ClientRepository()
        {
            posts = new List<Post>
            {
                new Post { Id = 101, Content = "Test1", PublishDate = DateTime.Now, Comments = new List<Comment>() },
                new Post { Id = 102, Content = "Test2", PublishDate = DateTime.Now, Comments = new List<Comment>() },
                new Post { Id = 103, Content = "Test3", PublishDate = DateTime.Now, Comments = new List<Comment>() },
                new Post { Id = 104, Content = "Test4", PublishDate = DateTime.Now, Comments = new List<Comment>() }
            };
        }

        public void InsertPost(Post post)
        {
            throw new NotImplementedException();
        }

        public void UpdatePost(Post post)
        {
            throw new NotImplementedException();
        }

        public void DeletePost(Post post)
        {
            throw new NotImplementedException();
        }

        public Post RetrievePost(int id)
        {
            throw new NotImplementedException();
        }

        public List<Post> RetrieveAllPosts()
        {
            return posts;
        }

        public void InsertComment(int postId, Comment comment)
        {
            var p = posts.FirstOrDefault(e => e.Id == postId);
            if (p != null)
                p.Comments.Add(comment);
        }

        public void UpdateComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public void DeleteComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public Comment RetrieveComment(int id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> RetrieveAllComments(int PostId)
        {
            throw new NotImplementedException();
        }*/
    }
}
