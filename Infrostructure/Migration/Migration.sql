-- Create Users table
CREATE TABLE Users (
                       UserId SERIAL PRIMARY KEY,  -- Automatically increments
                       FullName VARCHAR(150) NOT NULL,
                       Email VARCHAR(150) UNIQUE NOT NULL,
                       Phone VARCHAR(20),
                       City VARCHAR(100),
                       CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP  -- Defaults to current timestamp
);

-- Create Skills table
CREATE TABLE Skills (
                        SkillId SERIAL PRIMARY KEY,  -- Automatically increments
                        UserId INT NOT NULL,  -- FK referencing Users table
                        Title VARCHAR(150) NOT NULL,
                        Description TEXT,
                        CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,  -- Defaults to current timestamp
                        CONSTRAINT fk_user FOREIGN KEY (UserId) REFERENCES Users(UserId)  -- Foreign key constraint
);

-- Create Requests table
CREATE TABLE Requests (
                          RequestId SERIAL PRIMARY KEY,  -- Automatically increments
                          FromUserId INT NOT NULL,  -- FK referencing Users table
                          ToUserId INT NOT NULL,  -- FK referencing Users table
                          RequestedSkillId INT NOT NULL,  -- FK referencing Skills table
                          OfferedSkillId INT NOT NULL,  -- FK referencing Skills table
                          Status VARCHAR(20) NOT NULL CHECK (Status IN ('Pending', 'Accepted', 'Rejected')),  -- Restrict status to certain values
                          CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,  -- Defaults to current timestamp
                          UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,  -- Defaults to current timestamp
                          CONSTRAINT fk_from_user FOREIGN KEY (FromUserId) REFERENCES Users(UserId),  -- Foreign key for FromUserId
                          CONSTRAINT fk_to_user FOREIGN KEY (ToUserId) REFERENCES Users(UserId),  -- Foreign key for ToUserId
                          CONSTRAINT fk_requested_skill FOREIGN KEY (RequestedSkillId) REFERENCES Skills(SkillId),  -- Foreign key for RequestedSkillId
                          CONSTRAINT fk_offered_skill FOREIGN KEY (OfferedSkillId) REFERENCES Skills(SkillId)  -- Foreign key for OfferedSkillId
);

insert into Users(fullname, email, phone, city) values (@FullName, @Email, @Phone, @City);
select * from Users;
select * from Users where Id=@Id;
update Users set @FullName=fullname, @Email=email, @Phone=phone, @City=city where Id=@Id;
delete from Users where Id=@Id;

insert into Skills(UserId, Title, Description) values (@UserId, @Title, @Description);
select * from Skills;
select * from Skills where Id=@Id;
update Skills set UserId=@UserId, Title=@Title, Description=@Description where Id=@Id;
delete from Skills where Id=@Id;

insert into Requests( fromuserid, touserid, requestedskillid, offeredskillid, status) values ( @FromUserId, @ToUserId, @RequestedSkillId, @OfferedSkillId, @Status);
select * from Requests;
select * from Requests where Id=@Id;;
update Requests set FromUserId=@FromUserId,ToUserId=@ToUserId,RequestedSkillId=@RequestedSkillId,OfferedSkillId=@OfferedSkillId,Status=@Status where Id=@Id;
delete from Requests where Id=@Id;