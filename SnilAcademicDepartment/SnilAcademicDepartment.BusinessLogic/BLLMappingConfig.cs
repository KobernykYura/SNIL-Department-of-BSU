﻿using AutoMapper;
using SnilAcademicDepartment.BusinessLogic.DTOModels;
using SnilAcademicDepartment.DataAccess;
using System.Linq;

namespace SnilAcademicDepartment.BusinessLogic
{
    class BLLMappingConfig : Profile
    {
        public BLLMappingConfig()
        {
            // Mapping preview objects.
            this.CreateMap<PreView, PreViewModel>()
                .ForMember(des => des.Title, opt => opt.MapFrom(s => s.Header))
                .ForMember(des => des.Description, opt => opt.MapFrom(s => s.ShortDescription))
                .ForMember(des => des.Image, opt => opt.MapFrom(s => s.Image));

            // Mapping project objects.
            this.CreateMap<Project, ProjectModel>()
                .ForMember(des => des.ProjectId, opt => opt.MapFrom(s => s.ProjectId))
                .ForMember(des => des.ProjectTitle, opt => opt.MapFrom(s => s.ProjectName))
                .ForMember(des => des.ProjectStatus, opt => opt.MapFrom(s => s.ProjectStatus))
                .ForMember(des => des.Localisation, opt => opt.MapFrom(s => s.Language.LanguageCode))
                .ForMember(des => des.Image, opt => opt.MapFrom(s => s.Image.Image1))
                .ForMember(des => des.Document, opt => opt.MapFrom(s => s.Document.FileContent))
                .ForMember(des => des.CreationDate, opt => opt.MapFrom(s => s.CreationDate))
                .ForMember(des => des.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(des => des.ShortDescription, opt => opt.MapFrom(s => s.ShortDescription));

            //Mapping project preview objects.
            this.CreateMap<ProjectModel, ProjectPreview>()
                .ForMember(des => des.ProjectId, opt => opt.MapFrom(s => s.ProjectId))
                .ForMember(des => des.Title, opt => opt.MapFrom(s => s.ProjectTitle))
                .ForMember(des => des.ProjectStatus, opt => opt.MapFrom(s => s.ProjectStatus))
                .ForMember(des => des.Image, opt => opt.MapFrom(s => s.Image))
                .ForMember(des => des.Description, opt => opt.MapFrom(s => s.ShortDescription));

            // Mapping EducationBlock objects.
            this.CreateMap<EducationBlock, EducationBlockModel>()
                .ForMember(des => des.Title, opt => opt.MapFrom(s => s.Name))
                .ForMember(des => des.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(des => des.Image, opt => opt.MapFrom(s => s.Image1.Image1))
                .ForMember(des => des.Topics, opt => opt.MapFrom(s => s.EducationTopics.Select(p=>p.TopicName)));

            // Mapping HallOfFame objects.
            this.CreateMap<HallOfFame, Leader>()
                .ForMember(des => des.Image, opt => opt.MapFrom(s => s.Person.Image.Image1))
                .ForMember(des => des.FullName, opt => opt.MapFrom(s => s.Person.SecoundName + s.Person.PersonName + s.Person.FathersName));
        }
    }
}
