using MediatR;
using MojaApp.API.Dtos;

namespace MojaApp.API.Features.Studenti.Queries.GetAllStudenti
{
    public class GetAllStudentiQuery:IRequest<List<StudentResponse>>
    {

    }
}
