create database task_db;

use task_db;

create table tasks(
  task_id int primary key identity(1,1),
  task_title varchar(255) not null,
  task_description varchar(255) not null,
  reminder_time datetime null,
  is_completed bit default 0
);

select * from tasks;

SELECT task_title FROM tasks WHERE is_completed = 1;

drop table tasks;