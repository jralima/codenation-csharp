RESTORE DATABASE Codenation
FROM DISK = 'C:\GitHub\codenation-csharp\Modulo 7\Desafio\ConfiguracaoAutorizacaoAcessoApiJWT\Codenation.bak'
WITH MOVE 'Codenation' TO 'C:\GitHub\codenation-csharp\Modulo 7\Desafio\ConfiguracaoAutorizacaoAcessoApiJWT\Codenation.mdf',
MOVE 'Codenation_log' TO 'C:\GitHub\codenation-csharp\Modulo 7\Desafio\ConfiguracaoAutorizacaoAcessoApiJWT\Codenation_log.ldf'