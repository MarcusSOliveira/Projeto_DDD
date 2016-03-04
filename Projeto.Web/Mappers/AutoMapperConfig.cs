using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace Projeto.Web.Mappers
{
    public class AutoMapperConfig
    {
        //registrar as classes de configuração
        //criadas para o AutoMapper (Profile)
        public static void Register()
        {
            Mapper.Initialize(
                    m =>
                    {
                        m.AddProfile<EntityToModelMapping>();
                        m.AddProfile<ModelToEntityMapping>();
                    }
                );
        }
    }
}