SQL - Course: DATABASES - Databases Sample Exam
[at] SoftUni 
https://judge.softuni.bg/Contests/#!/List/ByCategory/8/Databases
---------------------------------------------------------------------------------
Problem 10.	Not Published Ads from the First Month
Find all not published ads, created in the same month and year like the earliest ad. Display for each ad its id, title, date and status. Sort the results by Id. Name the columns exactly like in the table below. Submit for evaluation the result grid with headers.
Id	Title	Date	Status
12	Free cat	2014-12-26 05:14:30.000	Waiting Approval
…	…	…	…

use Ads;
SELECT a.Id, a.Title, a.Date, s.Status
FROM Ads a
LEFT JOIN AdStatuses s ON a.StatusId = s.Id
WHERE s.Status <> 'Published' 
	AND (SELECT MONTH(MIN(Date)) FROM Ads) = MONTH(a.Date)  
	AND (SELECT YEAR(MIN(DATE)) FROM Ads) = YEAR(a.Date)
GO
---------------------------------------------------------------------------------
Problem 11.	Ads by Status
Display the count of ads in each status. Sort the results by status. Name the columns exactly like in the table below. Submit for evaluation the result grid with headers.
Status	Count
Inactive	3
Published	11
…	…

use Ads;

SELECT s.Status, COUNT (a.id) as Count
FROM Ads a
LEFT JOIN AdStatuses s ON a.StatusId = s.Id
GROUP BY (s.Status)
GO
---------------------------------------------------------------------------------
Problem 12.	Ads by Town and Status
Display the count of ads for each town and each status. Sort the results by town, then by status. Display only non-zero counts. Name the columns exactly like in the table below. Submit for evaluation the result grid with headers.
Town Name	Status	Count
Blagoevgrad	Inactive	1
Blagoevgrad	Published	1
Burgas	Published	1
…	…	…

use Ads;

SELECT t.Name as [Town Name], s.Status, COUNT(a.Id) as Count
FROM Ads a
RIGHT JOIN AdStatuses s ON a.StatusId = s.Id
RIGHT JOIN Towns t ON a.TownId = t.Id
GROUP BY t.Name, s.Status
HAVING COUNT (a.Id ) > 0
ORDER BY t.Name, s.Status
GO
---------------------------------------------------------------------------------
Problem 13.	* Ads by Users
Find the count of ads for each user. Display the username, ads count and "yes" or "no" depending on whether the user belongs to the role "Administrator". Sort the results by username. Name the columns exactly like in the table below. Submit for evaluation the result grid with headers.
UserName	AdsCount	IsAdministrator
admin	6	yes
didi	6	no
kiro	3	no
…	…	…

use Ads;

SELECT
  MIN(u.UserName) as UserName, 
  COUNT(a.Id) as AdsCount,
  (CASE WHEN admins.UserName IS NULL THEN 'no' ELSE 'yes' END) AS IsAdministrator
FROM 
  AspNetUsers u
  LEFT JOIN Ads a ON u.Id = a.OwnerId
  LEFT JOIN (
    SELECT DISTINCT u.UserName
    FROM AspNetUsers u
    LEFT JOIN AspNetUserRoles ur ON ur.UserId = u.Id
    LEFT JOIN AspNetRoles r ON ur.RoleId = r.Id
    WHERE r.Name = 'Administrator'
  ) AS admins ON u.UserName = admins.UserName
GROUP BY OwnerId, u.UserName, admins.UserName
ORDER BY u.UserName
GO
---------------------------------------------------------------------------------
Problem 14.	Ads by Town
Find the count of ads for each town. Display the ads count and town name or "(no town)" for the ads without a town. Display only the towns, which hold 2 or 3 ads. Sort the results by town name. Name the columns exactly like in the table below. Submit for evaluation the result grid with headers.
AdsCount	Town
3	(no town)
2	Blagoevgrad
3	Dobrich
…	…

use Ads;

SELECT COUNT (a.Id) as AdsCount, (CASE WHEN t.Name IS NULL  THEN '(no town)' ELSE t.Name END) as Town
FROM Towns t
FULL OUTER JOIN Ads a ON a.TownId = t.Id
GROUP BY t.Name
HAVING COUNT (a.Id) IN (2,3)
GO
---------------------------------------------------------------------------------
Problem 15.	Pairs of Dates within 12 Hours
Consider the dates of the ads. Find among them all pairs of different dates, such that the second date is no later than 12 hours after the first date. Sort the dates in increasing order by the first date, then by the second date. Name the columns exactly like in the table below. Submit for evaluation the result grid with headers.
FirstDate	SecondDate
2014-12-23 19:04:27.000	2014-12-24 05:15:37.000
2014-12-24 17:38:58.000	2014-12-24 20:21:11.000
2014-12-24 17:38:58.000	2014-12-24 23:53:17.000
…	…

use Ads;

SELECT a1.Date AS FirstDate, a2.Date AS SecondDate
FROM Ads a1, Ads a2
WHERE
	a2.Date > a1.Date AND
	DATEDIFF(second, a1.Date, a2.Date) < 12 * 60 * 60
ORDER BY a1.Date, a2.Date
GO
