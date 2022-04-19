USE PAR_MyBase


---- 1� �������
SELECT �������.[�������� ��������], �����.[����� ��������]
	FROM  ������� INNER JOIN ����� 
	ON �����.[����� ��������]  = �������.ID_��������

---- 2� �������
--SELECT �������.[�������� ��������], �����.[����� ��������]
--	FROM  ������� INNER JOIN ����� 
--	ON �����.[����� ��������]  = �������.ID_�������� AND  �������.[�������� ��������] LIKE '%�����%'

---- 3� �������
--SELECT T1.[�������� ��������], T2.[����� ��������]
--	FROM ������� AS T1, ����� AS T2
--	WHERE T2.[����� ��������]  = T1.ID_��������

--SELECT T1.[�������� ��������], T2.[����� ��������]
--	FROM ������� AS T1 , ����� AS T2
--	WHERE T2.[����� ��������]  = T1.ID_�������� AND T1.[�������� ��������] LIKE '%�����%'

----4� �������

SELECT ��������.�������, �����.[����� ��������],
		CASE
		WHEN (�������.[���������� ���� � ����] = 1) THEN '����'
		WHEN (�������.[���������� ���� � ����] = 2) THEN '���'
		ELSE 'AGS'
		END [���� � ����]
		FROM �������
		INNER JOIN ����� ON �������.ID_�������� = �����.[����� ��������]
		INNER JOIN �������� ON �����.[����� ��������] = ��������.ID_��������
		AND (�������.[���������� ���� � ����] BETWEEN 1 AND 2)
		ORDER BY ��������.������� DESC

----5� �������
		
		SELECT ��������.�������, �����.[����� ��������],
		CASE
		WHEN (�������.[���������� ���� � ����] = 1) THEN '����'
		WHEN (�������.[���������� ���� � ����] = 2) THEN '���'
		ELSE 'AGS'
		END [���� � ����]
		FROM �������
		INNER JOIN ����� ON �������.ID_�������� = �����.[����� ��������]
		INNER JOIN �������� ON �����.[����� ��������] = ��������.ID_��������
		AND (�������.[���������� ���� � ����] BETWEEN 1 AND 2)
		ORDER BY 
		( CASE
			WHEN (�������.[���������� ���� � ����] = 1) THEN 1
			WHEN (�������.[���������� ���� � ����] = 2) THEN 2
			ELSE 3
		END
		)


---- 6� ������� 

SELECT �������.[�������� ��������], �����.[����� ��������]
		FROM ������� LEFT OUTER JOIN �����
			ON �������.ID_�������� = �����.[����� ��������]

		
---- 7� ������� 
SELECT �������.[�������� ��������], �����.[����� ��������]
		FROM �����  RIGHT OUTER JOIN �������
			ON �������.ID_�������� = �����.[����� ��������]


---- 8� �������
SELECT	�������.[�������� ��������], �����.[����� ��������]
		FROM ����� full outer join �������
		ON �������.ID_�������� = �����.[����� ��������]
		WHERE �����.[����� ��������] IS NULL

SELECT	�������.[�������� ��������], �����.[����� ��������]
		FROM ����� full outer join �������
		ON �������.ID_�������� = �����.[����� ��������]
		WHERE �������.[�������� ��������] IS NULL

SELECT	�������.[�������� ��������], �����.[����� ��������]
		FROM ����� full outer join �������
		ON �������.ID_�������� = �����.[����� ��������]

-- 9� �������

SELECT �������.[�������� ��������], �����.[����� ��������]
	FROM  ������� CROSS JOIN ����� 
	where �����.[����� ��������]  = �������.ID_��������

