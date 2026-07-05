-- SEL_DATABASES.sql

SELECT
	ma.vchip + ',' + ma.vchporta + ' ' + ma.vchambiente AS vchServer,
	mb.vchbase AS vchDatabase
FROM multi_ambientes ma (nolock)
JOIN multi_bases mb (nolock) ON ma.multi_ambientes_id = mb.multi_ambientes_id
ORDER by ma.vchambiente, mb.vchbase
