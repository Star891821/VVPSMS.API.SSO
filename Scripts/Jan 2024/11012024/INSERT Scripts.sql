INSERT INTO MstUserRoles(role_name, activeYN, created_at,created_by,roletype_id) values ('Parent', 1, getdate(),1, 2)
INSERT INTO MstUserRoles(role_name, activeYN, created_at,created_by,roletype_id) values ('Teacher', 1, getdate(),1, 2)
INSERT INTO MstUserRoles(role_name, activeYN, created_at,created_by,roletype_id) values ('HOD', 1, getdate(),1, 2)
INSERT INTO MstUserRoles(role_name, activeYN, created_at,created_by,roletype_id) values ('GeneralOffice', 1, getdate(),1, 2)
INSERT INTO MstUserRoles(role_name, activeYN, created_at,created_by,roletype_id) values ('Management', 1, getdate(),1, 2)

INSERT INTO MstUsers(username,userpassword,user_givenName,user_surname,role_id,enforce2FA,created_at, created_by,useremail)
VALUES ('parent', 'parent', 'parent', 'parent', 2, 0,getdate(), 1, 'parent@gmail.com')

INSERT INTO MstUsers(username,userpassword,user_givenName,user_surname,role_id,enforce2FA,created_at, created_by,useremail)
VALUES ('teacher', 'teacher', 'teacher', 'teacher', 3, 0,getdate(), 1, 'teacher@gmail.com')

INSERT INTO MstUsers(username,userpassword,user_givenName,user_surname,role_id,enforce2FA,created_at, created_by,useremail)
VALUES ('hod', 'hod', 'hod', 'hod', 4, 0,getdate(), 1, 'hod@gmail.com')

INSERT INTO MstUsers(username,userpassword,user_givenName,user_surname,role_id,enforce2FA,created_at, created_by,useremail)
VALUES ('generaloffice', 'generaloffice', 'generaloffice', 'generaloffice', 5, 0,getdate(), 1, 'generaloffice@gmail.com')

INSERT INTO MstUsers(username,userpassword,user_givenName,user_surname,role_id,enforce2FA,created_at, created_by,useremail)
VALUES ('management', 'management', 'management', 'management', 6, 0,getdate(), 1, 'management@gmail.com')