select * from Products p 
inner join Categories c 
on c.CategoryID=p.CategoryID

select * from Products p
left join Categories c
on p.CategoryID=c.CategoryID

select * from Products p
right join Categories c
on p.CategoryID=c.CategoryID

select * from Products p
left join Categories c
on p.CategoryID=c.CategoryID
where c.CategoryID is null

select * from Products p
right join Categories c
on p.CategoryID=c.CategoryID
where p.CategoryID is null