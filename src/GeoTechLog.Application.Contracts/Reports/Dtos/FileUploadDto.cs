
public class FileUploadDto
{
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public long Length { get; set; }
    public byte[] Content { get; set; }
}
