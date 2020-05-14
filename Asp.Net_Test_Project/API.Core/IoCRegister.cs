using API.Repository.Abstract;
using API.Repository.Concrete;
using API.Service.Abstract;
using API.Service.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace API.Core
{
    public static class IoCRegister
    {
        public static void RegisterIoC(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IVoteService, VoteService>();
            services.AddTransient<IVoteRepository, VoteRepository>();

        }
    }
}
