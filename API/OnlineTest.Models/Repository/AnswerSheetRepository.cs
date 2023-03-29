using OnlineTest.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OnlineTest.Models.Repository
{
    public class AnswerSheetRepository : IAnswerSheetRepository
    {
        private readonly OnlineTestContext _context;

        public AnswerSheetRepository(OnlineTestContext context)
        {
            _context = context;
        }

        public bool AddAnswerSheet(List<AnswerSheet> AnswerSheets)
        {
            _context.Add(AnswerSheets);
             return _context.SaveChanges() > 0;
            
        }

        //public bool DeleteAnswerSheet(int id);
        //{
        //    _context.Entry(id).Property("Id").IsModified = true;
        //    return _context.SaveChanges() > 0;
        //}

        //public IEnumerable<AnswerSheet> GetAnswerSheet()
        //{
        //    return _context.AnswerSheets.ToList();

        //}

        //public IEnumerable <Answer> GetAnswerSheetByAnswerId(int Id, int AnswerId)
        //{
        //    return (from ans in _context.AnswerSheets
        //            join a in _context.Answers
        //            on ans.Id equals a.Id
        //            where ans.AnswerId == AnswerId && ans.Id == Id

        //            select new Answer
        //            {
        //                Id = ans.Id,
        //                CreatedOn = ans.CreatedOn

        //            }).ToList();


        //}

        //public bool GetAnswerSheetById(int AnswerId)
        //{
        //    return _context.AnswerSheets.FirstOrDefault(a => a.Id == Id);
        //}

        //public bool UpdateAnswerSheet(AnswerSheet AnswerSheets)
        //{
        //    _context.Entry(AnswerSheets).Property("Id").IsModified = true;
        //    _context.Entry(AnswerSheets).Property("QuestionId").IsModified = true;
        //    _context.Entry(AnswerSheets).Property("AnswerId").IsModified = true;
        //    return _context.SaveChanges() > 0;
        //}
    }
}
