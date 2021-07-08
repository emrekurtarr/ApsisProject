using ApsisYönetim.Core.Entities;
using ApsisYönetim.Core.Interfaces.Repositories;
using ApsisYönetim.Core.Interfaces.Services;
using ApsisYönetim.Core.Utilities.Result;
using ApsisYönetim.Service.Constants.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Service.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository = null;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<IResult> AddAsync(Note item)
        {
            var result = await _noteRepository.AddAsync(item);
            if(result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public async Task<IResult> Delete(Note item)
        {
            Note existNote = await _noteRepository.GetAsync(x => x.ID == item.ID);

            if (existNote == null)
            {
                return new ErrorDataResult<Note>(item,NoteConstants.NotFound);
            }

            var result = _noteRepository.Delete(item).Result;

            if (result > 0)
            {
                return new SuccessResult(NoteConstants.DeletedSuccessfully);
            }

            return new ErrorResult(NoteConstants.FailDeleted);
        }

        public async Task<IDataResult<List<Note>>> GetAllAsync(Expression<Func<Note, bool>> expression = null)
        {
            var result = await _noteRepository.GetAllAsync(expression);
            return new SuccessDataResult<List<Note>>(result.ToList());
        }

        public async Task<IDataResult<Note>> GetAsync(Expression<Func<Note, bool>> expression)
        {
            var message = await _noteRepository.GetAsync(expression);
            if(message == null)
            {
                return new ErrorDataResult<Note>();
            }
            return new SuccessDataResult<Note>(message);
        }

        public async Task<IResult> Update(Note item)
        {
            Note existNote = await _noteRepository.GetAsync(x => x.ID == item.ID);
            if(existNote != null)
            {
                existNote = item;
                var result = await _noteRepository.Update(existNote);
                if(result > 0)
                {
                    return new SuccessResult();
                }
                return new ErrorResult();
            }

            return new ErrorResult();
        }
    }
}
