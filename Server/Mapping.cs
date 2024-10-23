using AutoMapper;
using ElectronicDiary.Domain;
using Server.DTO;

namespace Server;

public class Mapping: Profile
{
    public Mapping()
    {
        CreateMap<Class, ClassDto>().ReverseMap();
        CreateMap<Grade, GradeDto>().ReverseMap();
        CreateMap<Student, StudentDto>().ReverseMap();
        CreateMap<Subject, SubjectDto>().ReverseMap();
    }
}
