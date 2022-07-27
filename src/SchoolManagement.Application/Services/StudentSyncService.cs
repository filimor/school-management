using System.Linq.Expressions;
using AutoMapper;
using SchoolManagement.Application.Data.StudentDtos;
using SchoolManagement.Application.Interfaces;
using SchoolManagement.Domain.Models;
using SchoolManagement.Infrastructure.Interfaces;

namespace SchoolManagement.Application.Services;

public class StudentSyncService : IStudentSyncService
{
    private readonly IMapper _mapper;
    private readonly ISyncUnitOfWork _unitOfWork;

    public StudentSyncService(ISyncUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public GetStudentDto Get(int id)
    {
        var student = _unitOfWork.StudentRepository.Get(id);
        return _mapper.Map<GetStudentDto>(student);
    }

    public IEnumerable<GetStudentDto> GetAll()
    {
        var students = _unitOfWork.StudentRepository.GetAll();
        return _mapper.Map<IEnumerable<GetStudentDto>>(students);
    }

    public void Add(CreateStudentDto studentDto)
    {
        var student = _mapper.Map<Student>(studentDto);
        _unitOfWork.StudentRepository.Add(student);
        _unitOfWork.Save();
    }

    public void Update(ModifyStudentDto studentDto)
    {
        var student = _mapper.Map<Student>(studentDto);
        _unitOfWork.StudentRepository.Update(student);
        _unitOfWork.Save();
    }

    public void Delete(ModifyStudentDto studentDto)
    {
        var student = _mapper.Map<Student>(studentDto);
        _unitOfWork.StudentRepository.Delete(student);
        _unitOfWork.Save();
    }

    public IEnumerable<GetStudentDto> Find(Expression<Func<Student, bool>> predicate)
    {
        var students = _unitOfWork.StudentRepository.Find(predicate);
        return _mapper.Map<IEnumerable<GetStudentDto>>(students);
    }
}
