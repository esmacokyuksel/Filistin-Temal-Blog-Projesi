﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class AuthorManager:IAuthorService
	{
		IAuthorDal _authordal;
		Repository<Author> repoauthor = new Repository<Author>();

		public AuthorManager(IAuthorDal authordal)
		{
			_authordal = authordal;
		}
		public void EditAuthor(Author p)
		{
			Author author = repoauthor.Find(x => x.AuthorID == p.AuthorID);
			author.AboutShort = p.AboutShort;
			author.AuthorName = p.AuthorName;
			author.AuthorImage = p.AuthorImage;
			author.AuthorAbout = p.AuthorAbout;
			author.AuthorTitle= p.AuthorTitle;
			author.Mail = p.Mail;
			author.Password = p.Password;
			author.PhoneNumber = p.PhoneNumber;

			 repoauthor.Update(author);
		}

		public List<Author> GetList()
		{
			return _authordal.List();
		}

		public Author GetByID(int id)
		{
			return _authordal.GetByID(id);
		}

		public void AuthorDelete(Author t)
		{
			_authordal.Delete(t);
		}

		public void TAdd(Author t)
		{
			_authordal.Insert(t);
		}

		public void TDelete(Author t)
		{
			_authordal.Delete(t);
		}

		public void TUpdate(Author t)
		{
			_authordal.Update(t);
		}
	}
}
