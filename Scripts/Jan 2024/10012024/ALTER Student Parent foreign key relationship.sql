ALTER TABLE Students
ADD parent_id int NOT NULL
ALTER TABLE Students
ADD FOREIGN KEY (parent_id) REFERENCES Parents(parent_id);