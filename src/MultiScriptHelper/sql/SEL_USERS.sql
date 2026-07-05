-- SEL_USERS.sql

SELECT
	mu.vchusuario AS vchUser,
	mu.vchsenha AS vchEncryptedPassword,
	mu.vchpath AS vchDesktopUserPath
FROM multi_usuario mu (nolock)
ORDER BY mu.vchusuario
