using System;
using Xunit;

namespace GradeBook.Test
{
    public class TypeTest
    {
        [Fact]
        public void GetBookRetursDifferentObjetcs()
        {
            var book1= GetBook("Book1");
            var book2=GetBook("Book2");

            Assert.Equal("Book1",book1.Name);
            Assert.Equal("Book2",book2.Name);
            Assert.NotSame(book1,book2);
            
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1= GetBook("Book1");
            var book2=book1;

            Assert.Equal("Book1",book1.Name);
            Assert.Equal("Book1",book2.Name);
            Assert.Same(book1,book2);
            Assert.True(object.ReferenceEquals(book1,book2));
            
        }
        [Fact]
        public void CanSetNameFromReference()
        {
            var book1= GetBook("Book1");
            SetName(book1,"New Name");

            Assert.Equal("New Name",book1.Name);
            
        }
        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1= GetBook("Book1");
            GetBookSetName(book1,"New Name");

            Assert.Equal("Book1",book1.Name);
            
        }
        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1= GetBook("Book1");
            GetBookSetName(ref book1,"New Name");

            Assert.Equal("New Name",book1.Name);
            
        }
        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name="Somsubhra";
            var uppername=MakeUpper(name);

            Assert.Equal("Somsubhra",name);
            Assert.Equal("SOMSUBHRA",uppername);
            
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }

        public void SetName(Book book,string name)
        {
            book.Name=name;
        }
        
        public void GetBookSetName(Book book, string name)
        {
            book=new Book(name);
        }
        public void GetBookSetName(ref Book book, string name)
        {
            book=new Book(name);
        }

        public string MakeUpper(string name)
        {
            return name.ToUpper();
        }
    }
}
