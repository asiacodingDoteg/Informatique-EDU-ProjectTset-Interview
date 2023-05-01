	CREATE FUNCTION dbo.ToTicks ( @DateTime datetime2 )
  RETURNS bigint
AS
BEGIN
    DECLARE @Days bigint = DATEDIFF( DAY, '00010101', cast( @DateTime as date ) );
    DECLARE @Seconds bigint = DATEDIFF( SECOND, '00:00', cast( @DateTime as time( 7 ) ) );
    DECLARE @Nanoseconds bigint = DATEPART( NANOSECOND, @DateTime );
    RETURN  @Days * 864000000000 + @Seconds * 10000000 + @Nanoseconds / 100;
END