create trigger ProductEklendi
on Products
after insert 
as begin
insert into Products (ProductName,UnitPrice) values ('deneme',12.5)
end

insert into Products (ProductName,UnitPrice) values ('deneme11',12.5)


create trigger SiparisEkle
on Satislar
after insert
as begin
declare @urunID int, @adet int
select @urunID=KitID, @adet=Adet from inserted
update Kitaplar set KitStok=KitStok-@adet where KitID=@urunID
end


insert into Satislar (KitID,Adet) values (1,5)



alter trigger StokIptalEt
on Satislar
after delete 
as begin
declare @KID int, @adet int
select @KID=KitID, @adet=Adet from deleted
update Kitaplar set KitStok=KitStok+@adet where KitID=@KID 
end

delete from Satislar where SatID=6





alter trigger StokDuzenle
on Satislar
after update
as begin
declare @KID int, @eskiadet int, @yeniadet int, @fark int
select @KID=KitID, @eskiadet=Adet from deleted
select @yeniadet=Adet from inserted
set @fark=@eskiadet-@yeniadet
update Kitaplar set KitStok=KitStok+@fark
end

update Satislar set Adet=15 where SatID=9