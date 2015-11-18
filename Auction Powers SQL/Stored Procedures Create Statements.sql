DELIMITER $$
CREATE DEFINER=`root`@`%` PROCEDURE `Insert_User`(
		Username varchar(16),
        Pass varchar(32),
        Email varchar(255)
)
begin
	
    if exists(select User_Id from User where User.Username = Username) then
		select -1; # username exists
    elseif exists(select User_Id from User where User.Email = Email) then
		select -2; #email exists
    else
		insert into auction_powers.User (
		Username, `Password`, Email, Create_Time)
        values (Username, Pass, Email, current_date());
        select last_insert_id();
    end if;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`%` PROCEDURE `User_Activation`(
	_User_Id int(11),
    _Activation_Code char(38))
BEGIN
	insert into auction_powers.User_Activation (
		User_Id, Activation_Code)
        values (_User_Id, _Activation_Code);
END$$
DELIMITER ;
DELIMITER $$
CREATE DEFINER=`root`@`%` PROCEDURE `Validate_User`(
	Username varchar(16),
    Pass varchar(32) )
BEGIN    
    declare id int;
    
    select User_Id into id
    from User
    where Username = Username and `Password` = Pass limit 1;
    
    if id is null then
		select -1; # invalid user name/password
	elseif exists(select User_Id from User_Activation where User_Id = id) then
		select -2; # user not yet activated
	else
		Update `User`
        Set Last_Login = current_date
        where User_Id = id;
        select User_Id from User Order by Last_Modified DESC Limit 1;
	end if;
END$$
DELIMITER ;
