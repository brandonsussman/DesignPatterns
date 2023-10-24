using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OtpNet;

[ApiController]
[Route("[controller]")]
public class OTPController : ControllerBase
{
    private const int OTPDigits = 6;
    private const int OTPValidityDurationMinutes = 5;

    private const string SecretKey = "your-secret-key"; // Replace with your secret key
    private const string EmailSender = "your-email-sender"; // Replace with your email address
    private const string EmailPassword = "your-email-password"; // Replace with your email password

    private Dictionary<string, string> userDatabase = new Dictionary<string, string>
    {
        { "1234567890", "user1@example.com" },
        { "0987654321", "user2@example.com" }
    };

    [HttpPost("generate-otp")]
    public IActionResult GenerateOTP([FromBody] GenerateOTPRequest request)
    {
        string idNumber = request.IdNumber;

        if (string.IsNullOrWhiteSpace(idNumber))
            return BadRequest(new { message = "ID number is required" });

        if (!IsIDNumberValid(idNumber))
            return BadRequest(new { message = "Invalid ID number" });

        string otp = GenerateTOTP(idNumber);
        SendOTPByEmail(idNumber, otp);

        return Ok(new { message = "OTP generated and sent successfully" });
    }

    [HttpPost("verify-otp")]
    public IActionResult VerifyOTP([FromBody] VerifyOTPRequest request)
    {
        string otp = request.Otp;
        string idNumber = request.IdNumber;

        if (string.IsNullOrWhiteSpace(otp) || string.IsNullOrWhiteSpace(idNumber))
            return BadRequest(new { message = "OTP and ID number are required" });

        if (!IsIDNumberValid(idNumber))
            return BadRequest(new { message = "Invalid ID number" });

        if (!IsOTPValid(otp, idNumber))
            return BadRequest(new { message = "Invalid OTP" });

        if (IsOTPValid(otp,idNumber))
        {
            Console.WriteLine("Valid " + otp);
        }
        // OTP is valid, generate a JWT
       
        string jwtToken = GenerateJwtToken(idNumber);

        return Ok(new { message = "OTP is valid", token = jwtToken });
    }

    private string GenerateTOTP(string idNumber)
    {
        byte[] secretBytes = Encoding.UTF8.GetBytes(SecretKey + idNumber);
        var totp = new Totp(secretBytes, step: OTPValidityDurationMinutes * 60); // Step in seconds

        return totp.ComputeTotp();
    }

    private bool IsOTPValid(string otp, string idNumber)
    {
        byte[] secretBytes = Encoding.UTF8.GetBytes(SecretKey + idNumber);
        var totp = new Totp(secretBytes, step: OTPValidityDurationMinutes * 60); // Step in seconds

        return totp.VerifyTotp(otp, out _, new VerificationWindow(2, 2)); // Allow a bit of time drift
    }

    private void SendOTPByEmail(string idNumber, string otp)
    {
        if (userDatabase.TryGetValue(idNumber, out string emailAddress))
        {
            /*using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
            {
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential(EmailSender, EmailPassword);

                MailMessage mailMessage = new MailMessage(EmailSender, emailAddress);
                mailMessage.Subject = "One-Time Password (OTP)";
                mailMessage.Body = $"Your OTP: {otp}";

                smtpClient.Send(mailMessage);
            }*/

            Console.WriteLine(otp);
        }
    }

    private bool IsIDNumberValid(string idNumber)
    {
        return userDatabase.ContainsKey(idNumber);
    }

    private string GenerateJwtToken(string idNumber)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("your - random - secret - key - with - at - least - 128 - bits");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("idNumber", idNumber)
            }),
            Expires = DateTime.UtcNow.AddMinutes(15), // Set the token expiration time as desired
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}

public class GenerateOTPRequest
{
    public string IdNumber { get; set; }
}

public class VerifyOTPRequest
{
    public string Otp { get; set; }
    public string IdNumber { get; set; }
}
