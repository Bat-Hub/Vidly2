﻿INSERT INTO Genres(Name,Id) values ('Horror',1)			
			INSERT INTO Genres(Name,Id) values ('Comdey',2)			
			INSERT INTO Genres(Name,Id) values ('Action',3)			
			INSERT INTO Genres(Name,Id) values ('Drama',4)			
			INSERT INTO Genres(Name,Id) values ('Romance',5)

			INSERT INTO MembershipTypes(Name,DiscountRate,DurationInMonths,SignUpFee,Id) values ('Monthly','10','1','1000',1)
			INSERT INTO MembershipTypes(Name,DiscountRate,DurationInMonths,SignUpFee,Id) values ('Quarterly','20','3','200',2)
			INSERT INTO MembershipTypes(Name,DiscountRate,DurationInMonths,SignUpFee,Id) values ('Halfyearly','30','6','300',3)
			INSERT INTO MembershipTypes(Name,DiscountRate,DurationInMonths,SignUpFee,Id) values ('Annually','40','12','400',4)
			
			INSERT INTO Customers(Name, MembershipTypeId,IsSubscribedToNewsletter) Values('Michael',1,1)
			INSERT INTO Customers(Name, MembershipTypeId,IsSubscribedToNewsletter) Values('Jack',2,0)
			INSERT INTO Customers(Name,MembershipTypeId,IsSubscribedToNewsletter) Values('Rilvan',3,1)
			INSERT INTO Customers(Name,MembershipTypeId,IsSubscribedToNewsletter) Values('Mukesh',1,1)
			INSERT INTO Customers(Name,MembershipTypeId,IsSubscribedToNewsletter) Values('Prabhu',2,1)

			INSERT INTO Movies(Name, GenreId,NumberInStock,DateAdded,ReleaseDate) Values('Batman Forver',3,2,'01/12/2018','01/12/2018')
			INSERT INTO Movies(Name,GenreId,NumberInStock,DateAdded,ReleaseDate) Values('The Dark Knight',3,2,'01/12/2018','01/12/2018')
			INSERT INTO Movies(Name,GenreId,NumberInStock,DateAdded,ReleaseDate) Values('Watchmen',3,2,'01/12/2018','01/12/2018')
			INSERT INTO Movies(Name,GenreId,NumberInStock,DateAdded,ReleaseDate) Values('Inception',4,2,'01/12/2018','01/12/2018')

		