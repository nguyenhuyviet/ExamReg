﻿using ExamReg.Data.Infrastructure;
using ExamReg.Data.Repositories;
using ExamReg.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamReg.Service
{
    public interface ISinhVienLophpService
    {
        void Add(SinhVienLophp sinhVien);
        void Update(SinhVienLophp sinhVien);
        SinhVienLophp Delete(int id);
        SinhVienLophp GetById(int id);
		bool checkDuplicate(Expression<Func<SinhVienLophp, bool>> predicate);
		SinhVienLophp GetByConDition(Expression<Func<SinhVienLophp, bool>> expression);
		IEnumerable<SinhVienLophp> GetMultiPaging(int page, int pageSize, string keyword,int lopHpId, out int totalRow);
		IEnumerable<SinhVienLophp> GetAll();
        void SaveChanges();
    }
    public class SinhVienLophpService : ISinhVienLophpService
    {
        ISinhVienLophpRepository _sinhVienLophpRepository;
        ISinhVienRepository _sinhVienRepository;
        ILopHocPhanRepository _lopHocPhanRepository;
        
        IUnitOfWork _unitOfWork;

        public SinhVienLophpService(ISinhVienLophpRepository sinhVienLophpRepository, ISinhVienRepository sinhVien, ILopHocPhanRepository lopHocPhan,  IUnitOfWork unitOfWork)
        {
            this._sinhVienLophpRepository = sinhVienLophpRepository;
            this._sinhVienRepository = sinhVien;
            this._lopHocPhanRepository = lopHocPhan;
            this._unitOfWork = unitOfWork;
        }

        public void Add(SinhVienLophp sinhVienLophp)
        {
            _sinhVienLophpRepository.Add(sinhVienLophp);
        }

        public void Update(SinhVienLophp sinhVienLophp)
        {
            _sinhVienLophpRepository.Update(sinhVienLophp);
        }

        public SinhVienLophp Delete(int id)
        {
            return _sinhVienLophpRepository.Delete(id);
        }

        public IEnumerable<SinhVienLophp> GetAll()
        {
            var result = _sinhVienLophpRepository.GetAll();
            foreach (var item in result)
            {
                item.SinhVien = _sinhVienRepository.GetSingleById(item.SinhVienId);
                item.LopHocPhan = _lopHocPhanRepository.GetSingleById(item.LophpId);
            }

            return result;
        }

        public SinhVienLophp GetById(int id)
        {
            var result = _sinhVienLophpRepository.GetSingleById(id);
            result.SinhVien = _sinhVienRepository.GetSingleById(result.SinhVienId);
            result.LopHocPhan = _lopHocPhanRepository.GetSingleById(result.LophpId);
            return result;
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

		public bool checkDuplicate(Expression<Func<SinhVienLophp, bool>> predicate)
		{
			return _sinhVienLophpRepository.CheckContains(predicate);
		}

		public SinhVienLophp GetByConDition(Expression<Func<SinhVienLophp, bool>> expression)
		{
			return _sinhVienLophpRepository.GetSingleByCondition(expression);
		}

		public IEnumerable<SinhVienLophp> GetMultiPaging(int page, int pageSize, string keyword, int lopHpId, out int totalRow)
		{
			IEnumerable<SinhVienLophp> query =  _sinhVienLophpRepository.GetMultiByAdm(keyword, lopHpId);

			
			totalRow = query.Count();

			return query.Skip((page - 1) * pageSize).Take(pageSize);
		}
	}

}
