using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setareh.DAL.Models.Common
{
    public class BasePaging<T>
    {
        public BasePaging()
        {
            Page = 1;
            TakeEntity = 10;
            HowManyPageShowAfterAndBefore = 5;
            Entities = new List<T>();
        }

        public int Page { get; set; }

        public int PageCount { get; set; }

        public int AllEntitesCount { get; set; }

        public int StartPage { get; set; }

        public int EndPage { get; set; }

        public int TakeEntity { get; set; }

        public int SkipEntity { get; set; }

        public int HowManyPageShowAfterAndBefore { get; set; }

        public List<T> Entities { get; set; }

        public PagingViewModel GetCurrentPaging()
        {
            return new PagingViewModel
            {
                EndPage = EndPage,
                Page = Page,
                StartPage = StartPage,
                PageCount = PageCount
            };
        }

        public async Task<BasePaging<T>> Paging(IQueryable<T> query)
        {
            TakeEntity = TakeEntity;

            var allEntitiesCount = query.Count();

            var pageCount = 0;

            try
            {
                pageCount = Convert.ToInt32(Math.Ceiling(allEntitiesCount / (double)TakeEntity));
            }
            catch (Exception)
            {
            }

            Page = Page > pageCount ? pageCount : Page;
            if (Page <= 0) Page = 1;
            AllEntitesCount = allEntitiesCount;
            HowManyPageShowAfterAndBefore = HowManyPageShowAfterAndBefore;
            SkipEntity = (Page - 1) * TakeEntity;
            StartPage = Page - HowManyPageShowAfterAndBefore <= 0 ? 1 : Page - HowManyPageShowAfterAndBefore;
            EndPage = Page + HowManyPageShowAfterAndBefore > pageCount ? pageCount : Page + HowManyPageShowAfterAndBefore;
            PageCount = pageCount;
            Entities = await Task.Run(() => query.Skip(SkipEntity).Take(TakeEntity).ToList());

            return this;
        }
    }

    public class PagingViewModel
    {
        public int Page { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int PageCount { get; set; }
    }
}
