using AutoMapper;
using MyTwitter.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTwitter.WWW.Models.MyTwitterModels
{
    public class TwitterUserViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Tweets { get; set; }

        public int Following { get; set; }

        public int Followers { get; set; }

        public int Likes { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            //Mapping for Id
            configuration.CreateMap<TwitterUser, TwitterUserViewModel>()
                .ForMember(uvm => uvm.Id, cfg => cfg.MapFrom(u => u.Id));

            configuration.CreateMap<TwitterUserViewModel, TwitterUser>()
                .ForMember(u => u.Id, cfg => cfg.MapFrom(uvm => uvm.Id));

            //Mapping for Name
            configuration.CreateMap<TwitterUser, TwitterUserViewModel>()
                .ForMember(uvm => uvm.Name, cfg => cfg.MapFrom(u => u.Name));

            configuration.CreateMap<TwitterUserViewModel, TwitterUser>()
                .ForMember(u => u.Name, cfg => cfg.MapFrom(uvm => uvm.Name));

            //Mapping for Tweets
            configuration.CreateMap<TwitterUser, TwitterUserViewModel>()
                .ForMember(uvm => uvm.Tweets, cfg => cfg.MapFrom(u => u.Tweets));

            configuration.CreateMap<TwitterUserViewModel, TwitterUser>()
                .ForMember(u => u.Tweets, cfg => cfg.MapFrom(uvm => uvm.Tweets));

            //Mapping for Following
            configuration.CreateMap<TwitterUser, TwitterUserViewModel>()
                .ForMember(uvm => uvm.Following, cfg => cfg.MapFrom(u => u.Following));

            configuration.CreateMap<TwitterUserViewModel, TwitterUser>()
                .ForMember(u => u.Following, cfg => cfg.MapFrom(uvm => uvm.Following));

            //Mapping for Followers
            configuration.CreateMap<TwitterUser, TwitterUserViewModel>()
                .ForMember(uvm => uvm.Followers, cfg => cfg.MapFrom(u => u.Followers));

            configuration.CreateMap<TwitterUserViewModel, TwitterUser>()
                .ForMember(u => u.Followers, cfg => cfg.MapFrom(uvm => uvm.Followers));

            //Mapping for Likes
            configuration.CreateMap<TwitterUser, TwitterUserViewModel>()
                .ForMember(uvm => uvm.Likes, cfg => cfg.MapFrom(u => u.Likes));

            configuration.CreateMap<TwitterUserViewModel, TwitterUser>()
                .ForMember(u => u.Likes, cfg => cfg.MapFrom(uvm => uvm.Likes));
        }
    }
}