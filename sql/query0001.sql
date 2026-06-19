-- Active: 1781782235426@@localhost@3306@practice0001
-- 使用するデータベースの名前を指定する
use practice0001;

-- 既存のテーブルがあれば
drop table if exists users;

-- テーブルを作る
create table users (
    id int auto_increment primary key,
    l_name varchar(50) not null,
    f_name varchar(50) not null,
    email varchar(100),
    create_at timestamp default current_timestamp
);

-- テストデータの挿入
insert into
    users (l_name, f_name, email)
values (
        'Yokoshima',
        'shotaro',
        'shotaro.sharo.8112@gmail.com'
    );

insert into users (l_name, f_name, email) values ('Yokoshima', 'masaya', 'example0001@gmail.com');

insert into users (l_name, f_name, email) values ('bobobo-bo', 'bo-bobo', 'example0002@gmail.com');

select * from users;