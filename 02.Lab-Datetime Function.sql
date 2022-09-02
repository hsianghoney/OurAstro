--	Module 11 - Lab02 ����ɶ����

--	�bSQL�����ɧڭ̷|�ݭn���� datetime ���������ƭȨӰ��P�_�C
--	DATENAME		: �Ǧ^��ܫ��w��������w datepart ���r��C
--		datepart �ѼƦ� : year�Aquarter�Amonth�Aweek�Aweekday�Adayofyear�Aday�A
--									hour�Aminute�Asecond�Amillisecond�Amicrosecond�Ananosecond
--	DATEPART		: �Ǧ^��ܫ��w��������w datepart ����ơC
--	DAY					: �Ǧ^��ܫ��w��������ѡ�����ơC
--	MONTH			: �Ǧ^��ܫ��w��������롨����ơC
--	YEAR				: �Ǧ^��ܫ��w��������~������ơC

select DateName (year, '2020-4-6 11:40');		-- yy-mm-dd
select DatePart (year, '2020-4-6 11:40');
select day ('4/6/2020 11:40');							-- mm/dd/yy
select month ('2020/4/6 11:40');
select year ('2020/4/6 11:40');

-- �Ǧ^�����ܫ��w�~���B����M����Ȫ� date ��
select DateFromParts (2020, 4, 7) as MyDate;                      -- Date

-- �Ǧ^���w����M�ɶ��޼ƪ� datetime2 ��
select DateTime2FromParts (2020, 4, 7, 23, 59, 59, 0, 6) as MyDate;     -- DateTime
select DateTime2FromParts (2020, 4, 7, 23, 59, 59, 0, 7) as MyDate; 
-- �Ǧ^���w����M�ɶ��޼ƪ� datetime ��
select DateTimeFromParts(2020, 4, 7, 23, 59, 59, 0) as MyDate; 

-- �Ǧ^���w����M�ɶ��� smlldatetime ��
select SmallDateTimeFromParts (2020, 4, 7, 23, 59) as MyDate;   -- no second

-- �Ǧ^�]�t���w��T�פ����w�ɶ��� time ��
select TimeFromParts (23, 59, 59, 0, 5) as MyTime;

-- DATEADD �|�N���w�� number ��(�H�a���t������ƧΦ�) 
-- �[���J date �Ȫ����w datepart�A�M��Ǧ^�ӭק�L���ȡC
-- �H�U���|�H 1 �����j���W datepart
declare @datetime2 datetime2 = '2020-04-06 12:49:10.1111111';  
select 
DateAdd (year, 1, @datetime2) as 'year',
DateAdd(quarter, 1, @datetime2) as 'quarter',       -- �u
DateAdd(month, 1, @datetime2) as 'month',
DateAdd(dayofyear, 1, @datetime2) as 'dayofyear',
DateAdd(day, 1, @datetime2) as 'day', 
DateAdd(week, 1, @datetime2) as 'week', 
DateAdd(weekday, 1, @datetime2) as 'weekday',
DateAdd(hour, 1, @datetime2) as 'hour',
DateAdd(minute, 1, @datetime2) as 'minute',
DateAdd(second, 1, @datetime2) as 'second',
DateAdd(millisecond, 1, @datetime2) as 'millisecond',
DateAdd(microsecond, 1, @datetime2) as 'microsecond', 
DateAdd(nanosecond, 1, @datetime2) as 'nanosecond';


--	EOMONTH �Ǧ^�]�t���w��������̫�@��
declare @date datetime = getdate();  
select @date
select eoMonth ( @date ) as 'This Month';       -- end of month
select eoMonth ( @date, 1 ) as 'Next Month';  
select eoMonth ( @date, -3 ) as 'Last Month';  

--	ISDATE
if isdate (	'2021-6-30 11:49:41.177') = 1
    print '���Ĥ��'  
else  
    print '�L�Ĥ��'; 

	if isdate ('2021-6-31 11:49:41.177') = 1
	    print '���Ĥ��'  
else  
    print '�L�Ĥ��'; 

--	FORMAT�Ǧ^�H���w�榡�P��ܩʤ�ƯS�ʩҮ榡�ƪ���
declare @date1 datetime2 = sysdatetime ();
select  --�y�k
format ( @date1, 'd') as '²�u���', 
format ( @date1, 'D') as '������',
format ( @date1, 'f') as '�������M²�u�ɶ�',
format ( @date1, 'F') as '�������M����ɶ�',
format ( @date1, 't') as '²�u�ɶ�',
format ( @date1, 'T') as '����ɶ�';
go

-- FORMAT �r���ơG�ϥΤ�ƯS�ʻP�榡�Ƥ��
select 
format (getdate(), 'F', 'en-US') as 'en-US_�^�� - ����',
format (getdate(), 'F', 'de-DE') as 'de-DE_�w�� - �w��', 
format (getdate(), 'F', 'zh-TW') as 'zh-TW_���� - �x�W', 
format (getdate(), 'F', 'zh-CN') as 'zh-CN_���� - ����',
format (getdate(), 'F', 'ko-KR') as 'ko-KR_���� - ����';
go


--	���o�t�Τ���M�ɶ����禡
--		�M�צb�W���ɡA�p�G���i��O������A�ȥ��Ҽ{�ϥ� UTC ��ڼзǮɶ��A
--		�קK�U��ɰϪ��t���y���t�ο��áA�Ҧp�I�ƧI���B�ӫ~�S�f�����K���C

select 
SysDateTime() as 'SysDateTime',
SysDateTimeOffset() as 'SysDateTimeOffset' ,
SysUtcDateTime() as 'SysUtcDateTime',
current_timestamp as 'current_timestamp',
getdate() as 'getdate' ,
GetUtcDate() as 'GetUtcDate';  


--  ���禡�|�Ǧ^��V���w startdate �M enddate �����w datepart �ɭ����p�� (�@���a���t������ƭ�)�C
--  startdate �M enddate ������ int �t���A�H datepart �ҳ]�w���ɭ���ܡC
declare @dt1 datetime2 = '2006-01-01 00:00:00.0000000';  
declare @dt2 datetime2 = getdate();  

select @dt1 as dt1, @dt2 as dt2                                             --@dt2-@dt1
select DateDiff (year,				@dt1, @dt2) as diff_year;
select DateDiff (quarter,			@dt1, @dt2) as diff_quarter;
select DateDiff (month,			@dt1, @dt2) as diff_month;
select DateDiff (dayofyear,		@dt1, @dt2) as diff_dayofyear;
select DateDiff (day,				@dt1, @dt2) as diff_day;
select DateDiff (week,				@dt1, @dt2) as diff_week;
select DateDiff (hour,				@dt1, @dt2) as diff_hour;
select DateDiff (minute,			@dt1, @dt2) as diff_minute;
select DateDiff (second,			@dt1, @dt2) as diff_second;
--select DateDiff (millisecond,	@dt1, @dt2) as diff_ms;
--select DateDiff (microsecond,@dt1, @dt2) as diff_us;
