
namespace AbstrakteDatentypen
{
    internal interface IFileInfo
    {
        string Extension { get; }
    }

    internal interface IPersistable : IFileInfo
    {
        string FileName { get; }

        bool Save();

        bool Load(string fromFilename);
    }


    internal abstract class Persistable
    {
        public abstract string FileName { get; }

        public abstract bool Save();

        public abstract bool Load(string fromFilename);
    }
}
