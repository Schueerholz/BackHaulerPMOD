/* BHPMODICD.H                                 
 
   This header file works as an interface control document (ICD) as it establishes
   an agreement between the data controller (DC) API and the device about how 
   system data are interpreted. 
   
   This ICD is for PMOD host baseline (Backhauler PMOD).
   
*/

#ifndef BHPMODICD_H
#define BHPMODICD_H
            
/* This header file works as an interface control document (ICD) as it establishes
   an agreement between the data controller (DC) API and the device about what USB 
   packet data means.  Generally, these instrument control functions have a very 
   simple command/response protocol.  
   
   Establishing general terms:
   
   Each message in either direction will have a token, a byte count, and data.  
   While the byte count is often fixed, using this consistent approach makes variable 
   messages straight forward.  Thus, in both directions, the basic message format
   is as follows.

   <TOKEN><BYTE COUNT><DATA AS DEFINED PER MESSAGE TOKEN>

   The token is a single byte.  The count is a single byte and represents the 
   number of bytes in the data portion of the message, up to 62.  If more than 62 bytes
   are required in the message data, then the command must establish a data phase for 
   which subsequent packets contain only the data.  This is described further below.
   The endianess of the data is message specific, but is generally big endian because
   the 8051 is big endian.

   The SiLabs USB subsystem works in 64 byte maximum packets.  Thus, if a message 
   is more than 64 bytes in either direction, it will be necessary to gather multiple 
   packets.  Many simple instrument devices work with far fewer than 64 bytes of data 
   in any transaction.  However, if a device has a file transfer function, such as 
   loading an FGPA, then there may be significantly more data.  In this case a command 
   will be established to put the device into a file transfer mode for an expected number 
   of bytes, and after the file is transferred the device will return to command mode.
*/

/*--------------------------------------------------------------------------*/

/* Device information */
/* NOTE - In the baseline these codes are the Silicon Labs defaults for a USBExpress device.
   That should allow development using the Silicon Labs USBExpress SDK baseline drivers 
   without the need for driver customization and associated hassles.  However, outside 
   of a development environment directly associated with the SDK, this would not be a
   reasonable or effective approach.
*/ 
#define BHPMOD_VENDOR_ID                            0x10C4
#define BHPMOD_PRODUCT_ID                           0xEA61
/* Application shared data structures and definitions */

// PMOD pins accessed by discrete I/O functions
// Generally, the user will want to define the pin number to some more meaningful name.  
// A few such generic names for various configurations are included here.  Invalid pin
// numbers are generally ignored by the embedded software, with a write functioning as
// a no operation (NOP) and a read returning 0.  The same approach is taken for writes  
// of any pin that cannot be written in the presently active configuration.  Such errors
// are generally coding related problems or intentional, making error checking these
// not a good use of resources.  Any response packet will not flag such errors, 
// making them simply benign. 

// Basic pin numbers - Note that for these it would be acceptable practice to use the value rather than the define, 
// which is shown here for reference only and is not expected to change from this direct representation.
#define PMOD_PIN1                                   1       
#define PMOD_PIN2                                   2
#define PMOD_PIN3                                   3
#define PMOD_PIN4                                   4
#define PMOD_PIN7                                   7
#define PMOD_PIN8                                   8
#define PMOD_PIN9                                   9
#define PMOD_PIN10                                  10        
// Using the following allows the programmer to convey more meaning in code for use in related configurations.   
#define PMOD_PIN_CTS                                1       
#define PMOD_PIN_RTS                                4
#define PMOD_PIN_INT                                7
#define PMOD_PIN_RESET                              8
// The following is the only specific reference in the baseline to the discrete I/O functionality "PMOD Type 5, H-Bridge"  
#define PMOD_PIN_DIR                                1       
#define PMOD_PIN_EN                                 2
#define PMOD_PIN_SA                                 3
#define PMOD_PIN_SB                                 4
// The following is the only specific reference in the baseline to the discrete I/O functionality "PMOD Type 6, Dual H-Bridge"  
#define PMOD_PIN_DIR1                               1       
#define PMOD_PIN_EN1                                2
#define PMOD_PIN_DIR2                               3
#define PMOD_PIN_EN2                                4
// The following pins are associated with specific configurations and would not be writeable while configured as such.  
// They would be writeable when operating with discrete I/O, such as bit banging (gasp!).  They are always readable, 
// though this would be of limited value in the associated configuration, except perhaps in some sort of debug capacity.
#define PMOD_PIN_TXD                                2
#define PMOD_PIN_RXD                                3
#define PMOD_PIN_NSS                                1
#define PMOD_PIN_MOSI                               2
#define PMOD_PIN_MISO                               3
#define PMOD_PIN_SCK                                4
#define PMOD_PIN_SCL                                9
#define PMOD_PIN_SDA                                10
// Invalid pin for which commands are processed but no logic is affected.  
// This is also the operation for any other invalid pin number or operation otherwise not allowed.
#define PMOD_NOP                                    0       

/*--------------------------------------------------------------------------*/

/* Command/response token definitions 

   Convention - while not required the following are useful guides -
   a) command tokens have the MSB = 0, response tokens MSB = 1
   b) device specific tokens start at 0x10
   c) token applying to a generalized device are less than 0x10
*/

/* The following tokens apply to the PMOD host (tokens > 0x10) */

// PMOD Set Pin Drive
// This token is followed by a length of 2, a byte defining which pin on the PMOD connector to affect 
// as defined above, and the new drive configuration of that pin (1/0).  The drive configuration of a pin 
// can be set to push-pull (1) or passive pull-up (0). The passive pull-up is weak and the pin can be 
// used as an input if the output value is set to 1 (passively pulled to logic high).  Any state value 
// other than 0 is interpreted as 1.  This operation is considered a write, and is subject to the same
// limitations as a write command.  Response is status, which will generally show no error unless the 
// command is not properly formed. See notes with pin definitions.  
#define TOKEN_COMMAND_PMOD_SET_PIN_DRIVE            0x10
#define PMOD_PIN_DRIVE_PASSIVE                      0       /* This is the default */
#define PMOD_PIN_DRIVE_PUSH_PULL                    1

// PMOD Write Pin
// This token is followed by a length of 2, a byte defining which pin on the PMOD connector to write 
// as defined above, and the new state of that pin (1/0).  Any state value other than 0 is interpreted as 1.
// Response is status, which will generally show no error unless the command is not properly formed.
// See notes with pin definitions.  
#define TOKEN_COMMAND_PMOD_WRITE_PIN                0x11

// PMOD Read Pin 
// This token is followed by a length of 1 and a byte defining which pin on the PMOD connector to read 
// as defined above.  The response will be TOKEN_RESPONSE_PMOD_READ_PIN or status if the command is 
// not properly formed.  See notes with pin definitions. 
#define TOKEN_COMMAND_PMOD_READ_PIN                 0x12

// PMOD Read Pin Response
// This message is in response to the PMOD read pin command token.  This token is followed by a length of 1 
// and the 1/0 state of the pin requested.  If the pin number to read was not valid, then the return value 
// will be 0 without indication of any error.  
#define TOKEN_RESPONSE_PMOD_READ_PIN                0x92

// PMOD Set Configuration
// This token is followed by a length of 1 and a byte representing the desired configuration as defined here.
// Changing the configuration resets any discrete I/O to the default settings for that configuration, so any 
// unique I/O requirements will have to be configured after this step.  This command can act as a reset in 
// this sense even if the configuration is not otherwise changed.  If the configuration specified is not valid, 
// then the default is installed. The response is status, which expected to show no error.
#define TOKEN_COMMAND_PMOD_SET_CONFIGURATION        0x20
#define PMOD_CONFIGURATION_IO_ONLY                  0       /* This is the default */
#define PMOD_CONFIGURATION_SPI                      1
#define PMOD_CONFIGURATION_I2C                      2
#define PMOD_CONFIGURATION_SERIAL                   3

/* The following commands are configuration specific.  These commands can always be executed, 
   but they will have no effect or no meaningful effect unless the configuration is set 
   to use them.  They are essentially inhibited in embedded software unless configured for
   the associated operation.
*/

// Set SPI Clock Phase
// This token is followed by a length of 1 and a byte representing the desired SPI clock phase as defined here.
// All subsequent SPI transactions will use this clock phase.  This setting is independent of the configuration
// and will not be reset by changing the configuration. If the clock phase specified is not valid, then the 
// default is installed. The response is status, which expected to show no error.  Note that some conventions
// for SPI call this setting "clock mode", and these numbers follow the "mode" definitions normally used.
// However, we do see some variation in "mode" definitions used in practice, such that it seems better to use 
// our own terms here and describe exactly what they mean.
#define TOKEN_COMMAND_SET_SPI_CLOCK_PHASE           0x30
#define SPI_CLOCK_PHASE_0                           0       /* Default - Clock idles low, slave accepts data on rising clock, master changes data on falling clock (POL=0, PHA=0) */
#define SPI_CLOCK_PHASE_1                           1       /* Clock idles low, slave accepts data on falling clock, master changes data on rising clock (POL=0, PHA=1) */
#define SPI_CLOCK_PHASE_2                           2       /* Clock idles high, slave accepts data on falling clock, master changes data on rising clock (POL=1, PHA=0) */
#define SPI_CLOCK_PHASE_3                           3       /* Clock idles high, slave accepts data on rising clock, master changes data on falling clock (POL=1, PHA=1) */

// SPI Transactions
// This command sends the specified number of bytes over the SPI bus and collects bytes from the SPI 
// bus at the same time.  In the PMOD device, the chip select is fixed and there is only one SPI 
// device with which to communicate.  The chip select time and clock rate are also fixed at relatively 
// slow but reliable values defined by the embedded code.  The clock phase information may be device 
// specific and is configured with a separate command.  The token is followed by a count equal to the 
// bytes to be sent (up to 62) and the array of bytes.  The embedded code returns the response with 
// the same number of bytes.  All SPI transactions receive bytes from the SPI device as they are written.  
// It is up to the user to manage and interpret the data.  For example, it is typical to write all 
// 1's to a device where input data are expected, but this is entirely device dependant.  This command 
// simply allows the host software to manage an SPI transaction.  
#define TOKEN_COMMMAND_SPI_TRANSACTION              0x31
#define TOKEN_RESPONSE_SPI_TRANSACTION              0xB1

// I2C Transactions
// These transactions send and return the entire content of an I2C transaction in the message contents.  
// The general format is as follows
// <TOKEN_COMMAND_I2C_<read/write>><COUNT+5><DEVICE ADDRESS><SUBADDR SIZE><2 SUBADDR BYTES, LEFT JUSTIFIED MSB FIRST><COUNT><COUNT DATA BYTES>
// The response will set the COUNT field to the number of bytes actually read or written.  The response will be
// the same format with the COUNT and bytes actually read or written.  The subaddress in this format is presently 
// limited to 2 bytes, but a longer subaddress can be included with the data instead, unless the device needs 
// an I2C restart between the address and the data.  The subaddress must always be included, with the size determining 
// the number of subaddress bytes actually applied.  If the subaddress is one byte, the first byte of the 
// two provided will be sent to the peripheral.  If the configuration is not set for I2C, these commands will 
// still behave like they processed correctly, except they that will return a 0 count.  
#define TOKEN_COMMAND_I2C_WRITE                     0x40
#define TOKEN_RESPONSE_I2C_WRITE                    0xC0
#define TOKEN_COMMAND_I2C_READ                      0x41
#define TOKEN_RESPONSE_I2C_READ                     0xC1

// Serial Transactions
// These transactions send or return data by handshake with the serial buffers in the embedded software.  
// The format of the command and response are the same, with the the general format is as follows
// <TOKEN_COMMAND_SERIAL_<read/write>><COUNT><COUNT DATA BYTES>
// The following description of the transaction is set to comply with the general ICD format but is 
// also useful in the sense that it provides definite information about the transaction results.
// To send data, set COUNT to the number of bytes to send and follow with those bytes.  The return packet 
// will be a copy of what was sent, including the number of bytes actually sent followed by those bytes.
// To read data, set COUNT to the number of bytes to read and follow with arbitrary data (use 0xFF bytes or
// whatever is in the return memory the host is looking to fill).  The return packet will be the same format
// as what was sent with the count set to the number of bytes actually read and followed by those bytes.
// The read/write will be throttled by available space or data available in the buffers.  If the configuration
// is not set for serial, these commands will still behave like they processed correctly, except that they 
// will return a 0 count.  The read is non-blocking, so it will return a 0 count if no bytes are available.
// PMOD notes - For the PMOD host function, serial is not a common need, so this functionality is much more 
// limited than it could be.  Needs of serial PMOD peripherals are also generally limited and slow speed,
// so it is most common to transact one byte at a time, and baseline host software is written that way.
// The serial settings are 9600,N,8,1 and can be changed only in embedded code.  This kind of option setting
// functionality, handshake modes, and so on could clearly be extended if the demand was there.  However, 
// there are generally  better ways to interface a peripheral that had such needs.  
#define TOKEN_COMMAND_SERIAL_WRITE                  0x50
#define TOKEN_RESPONSE_SERIAL_WRITE                 0xD0
#define TOKEN_COMMAND_SERIAL_READ                   0x51
#define TOKEN_RESPONSE_SERIAL_READ                  0xD1

/* The following tokens apply to all devices (token < 0x10) */

// Get Status 
// Response is the status response message
#define TOKEN_COMMAND_GET_STATUS                    0x00

// Status Message
// This status response is returned by request and also generally when no other data 
// are expected to be returned as a response.  This can act as an acknowledgement.  
// While many commands don't really need an acknowledgement to function well, there are
// times when a command may take a while to process.  In general, the status response 
// will be returned when processing is complete.  In some cases it may be used to indicate 
// the device is busy or has encountered a problem.
#define TOKEN_RESPONSE_STATUS                       0x80
// The status message contains the token followed by a count of one and a single 
// data byte indicating basic status as an OR of the bits defined below.
// Generally, any error status is self clearing.  When the next command requiring
// a status response is sent the status will be determined again.  This allows
// some commands to be followed by a poll for status change.  Not all status bits
// are used by all applications, but at least general use bits are defined while 
// application specific bits can be added.
#define STATUS_BIT_COMMAND_MODE_READY               0x01
#define STATUS_BIT_BUSY                             0x02    /* Not used for PMOD */ 
#define STATUS_BIT_ERROR                            0x04
#define STATUS_BIT_POWER_ON                         0x20    /* Always 1 for PMOD */
#define STATUS_BIT_DATA_IN_PHASE                    0x40    /* Not used for PMOD */
#define STATUS_BIT_DATA_OUT_PHASE                   0x80    /* Not used for PMOD */

// Test Function
// The test message is free form.  Generally, the data will include a subtoken
// and data regarding what test action to perform.  This will be an agreement
// between the test code in the device and the test code in the DCAPI and 
// governed only at that level.  This message is not to be used in production.
// Response is a test response with data as defined by the test code.
#define TOKEN_COMMAND_TEST                          0x0F
#define TOKEN_RESPONSE_TEST                         0x8F

/*--------------------------------------------------------------------------*/

#endif



