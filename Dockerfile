FROM python:3.11-slim AS builder

WORKDIR /app
RUN apt-get update \
    && apt-get install -y --no-install-recommends build-essential \
    && rm -rf /var/lib/apt/lists/*

COPY . .
RUN cd Heart/Crypto && python setup.py build_ext --inplace

FROM python:3.11-slim
WORKDIR /app
COPY --from=builder /app /app

ENV PYTHONUNBUFFERED=1
ENV PORT=9339
EXPOSE 9339

CMD ["python", "start.py"]
