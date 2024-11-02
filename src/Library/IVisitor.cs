namespace Library;

public interface IVisitor<T>
{
    void Visit(Node<T> node);
}