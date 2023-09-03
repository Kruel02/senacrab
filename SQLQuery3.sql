select * from Cliente;
select * from Conta;

create procedure CadastrarConta @idCliente int, @TipoConta varchar(50), @SaldoConta Decimal(10,2),@StatusConta varchar(30)
as
Select * from Conta where IDCliente = @idCliente and TipoConta = @TipoConta and SaldoConta = @SaldoConta and StatusConta = @StatusConta 
select @@IDENTITY as 'UltimoID'
go;

exec CadastrarConta 4, 'Correntista', 1200, 'ativa';


create procedure pi_Conta_48
@idCorrentista int,
@TipoConta varchar(50),
@saldo decimal(10,2),
@statusConta varchar(10)
as
insert into conta (IdCliente, TipoConta, SaldoConta, StatusConta )
values (@idCorrentista, @TipoConta, @saldo, @statusConta)
select @@identity as 'ultimoID'

exec pi_Conta_48 4, 'Correntista', 1200, 'ativa';

